using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2_CommandTextEditor
{
    public static class CommandParser
    {
        // Разбирает файл команд и возвращает список объектов, описывающих команды
        public static List<CommandData> ParseCommands(string filePath)
        {
            var commands = new List<CommandData>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string trimmed = line.Trim();
                string[] parts = trimmed.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                string cmd = parts[0].ToLower();
                CommandData data = new CommandData { CommandName = cmd };

                try
                {
                    switch (cmd)
                    {
                        case "copy":
                            if (parts.Length >= 3)
                            {
                                data.From = int.Parse(parts[1]);
                                data.To = int.Parse(parts[2]);
                            }
                            break;
                        case "paste":
                            if (parts.Length >= 2)
                                data.Position = int.Parse(parts[1]);
                            break;
                        case "insert":
                            if (parts.Length >= 3)
                            {
                                data.Position = int.Parse(parts[1]);
                                // остальная часть строки – текст для вставки
                                data.InsertString = string.Join(" ", parts, 2, parts.Length - 2);
                            }
                            break;
                        case "delete":
                            if (parts.Length >= 3)
                            {
                                data.From = int.Parse(parts[1]);
                                data.To = int.Parse(parts[2]);
                            }
                            break;
                        case "undo":
                        case "redo":
                            // ничего дополнительно
                            break;
                        default:
                            throw new Exception($"Неизвестная команда: {cmd}");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка в строке '{line}': {ex.Message}");
                }
                commands.Add(data);
            }
            return commands;
        }
    }

    // Класс для хранения данных команды
    public class CommandData
    {
        public string CommandName { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Position { get; set; }
        public string InsertString { get; set; } = "";
    }
}