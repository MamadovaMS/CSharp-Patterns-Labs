using System;
using System.IO;
using System.Windows.Forms;

namespace Lab2_CommandTextEditor
{
    public partial class Form1 : Form
    {
        private TextEditor _editor;
        private CommandInvoker _invoker;

        // Элементы, которые создадим программно
        private TextBox txtDisplay;
        private Button btnLoadAndRun;
        private Button btnUndo;
        private Button btnRedo;

        public Form1()
        {
            InitializeComponent(); // это обязательно, даже если форма пустая

            // Создаём текстовое поле
            txtDisplay = new TextBox();
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Multiline = true;
            txtDisplay.ReadOnly = true;
            txtDisplay.ScrollBars = ScrollBars.Vertical;
            txtDisplay.Dock = DockStyle.Fill;      // займёт всё свободное место
            txtDisplay.Font = new System.Drawing.Font("Consolas", 10);

            // Создаём панель для кнопок (чтобы они не мешали тексту)
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 50;

            // Кнопка "Загрузить и выполнить"
            btnLoadAndRun = new Button();
            btnLoadAndRun.Name = "btnLoadAndRun";
            btnLoadAndRun.Text = "Загрузить и выполнить";
            btnLoadAndRun.Dock = DockStyle.Left;
            btnLoadAndRun.Width = 150;
            btnLoadAndRun.Click += BtnLoadAndRun_Click;

            // Кнопка Undo
            btnUndo = new Button();
            btnUndo.Name = "btnUndo";
            btnUndo.Text = "Undo";
            btnUndo.Dock = DockStyle.Left;
            btnUndo.Width = 80;
            btnUndo.Click += BtnUndo_Click;

            // Кнопка Redo
            btnRedo = new Button();
            btnRedo.Name = "btnRedo";
            btnRedo.Text = "Redo";
            btnRedo.Dock = DockStyle.Left;
            btnRedo.Width = 80;
            btnRedo.Click += BtnRedo_Click;

            // Добавляем кнопки на панель
            buttonPanel.Controls.Add(btnLoadAndRun);
            buttonPanel.Controls.Add(btnUndo);
            buttonPanel.Controls.Add(btnRedo);

            // Добавляем панель и текстовое поле на форму
            this.Controls.Add(txtDisplay);
            this.Controls.Add(buttonPanel);

            // Инициализируем редактор и инвокер
            _editor = new TextEditor();
            _invoker = new CommandInvoker();
        }

        // Обработчик основной кнопки
        private void BtnLoadAndRun_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Выберите файл с исходной строкой";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string initialText = File.ReadAllText(openFileDialog1.FileName).Trim();

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Title = "Выберите файл с командами";
            if (openFileDialog2.ShowDialog() != DialogResult.OK) return;

            _editor = new TextEditor(initialText);
            _invoker = new CommandInvoker();

            var commands = CommandParser.ParseCommands(openFileDialog2.FileName);
            foreach (var cmdData in commands)
            {
                ICommand cmd = null;
                switch (cmdData.CommandName)
                {
                    case "copy":
                        cmd = new CopyCommand(_editor, cmdData.From, cmdData.To);
                        break;
                    case "paste":
                        cmd = new PasteCommand(_editor, cmdData.Position);
                        break;
                    case "insert":
                        cmd = new InsertCommand(_editor, cmdData.Position, cmdData.InsertString);
                        break;
                    case "delete":
                        cmd = new DeleteCommand(_editor, cmdData.From, cmdData.To);
                        break;
                    case "undo":
                        _invoker.Undo();
                        break;
                    case "redo":
                        _invoker.Redo();
                        break;
                }
                if (cmd != null)
                    _invoker.ExecuteCommand(cmd);
            }

            txtDisplay.Text = _editor.Text;
            MessageBox.Show($"Результат:\n{_editor.Text}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            _invoker.Undo();
            txtDisplay.Text = _editor.Text;
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            _invoker.Redo();
            txtDisplay.Text = _editor.Text;
        }
    }
}