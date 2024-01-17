using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReaderApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
        }

        private async Task ReadFileAsync(string filePath, CancellationToken cancellationToken)
        {
            long fileSize = new FileInfo(filePath).Length;

            using (StreamReader reader = new StreamReader(filePath))
            {
                char[] buffer = new char[4096];

                int bytesRead;
                long totalBytesRead = 0;

                while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(true)) > 0)
                {
                    totalBytesRead += bytesRead;
                    int progressPercentage = (int)((totalBytesRead * 100) / fileSize);

                    UpdateProgressBar(progressPercentage);

                    

                    
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }
        }

        private void ResetProgressBar()
        {
            progressBar1.Value = 0;
            
            label1.Text = "Прогрес: 0%";
        }

        private void UpdateProgressBar(int percentage)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action<int>(UpdateProgressBar), percentage);
            }
            else
            {
                progressBar1.Value = Math.Min(percentage, progressBar1.Maximum);
                label1.Text = $"Прогрес: {percentage}%";
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\admin\Desktop\11.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    ResetProgressBar();
                    btnFinish.Enabled = false;

                    cancellationTokenSource = new CancellationTokenSource();

                    await Task.Run(() => ReadFileAsync(filePath, cancellationTokenSource.Token), cancellationTokenSource.Token);

                    MessageBox.Show("Читання завершено!");
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Операцію відмінено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnFinish.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Файл не існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                ResetProgressBar();
            }
        }

        private void btnFinish_Click_1(object sender, EventArgs e)
        {
            
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }

            
            Application.Exit();
        }
    }

    public static class TaskExtensions
    {
        public static async Task<TResult> WithCancellation<TResult>(this Task<TResult> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(s => ((TaskCompletionSource<bool>)s!).TrySetResult(true), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task))
                {
                    throw new OperationCanceledException(cancellationToken);
                }
            }
            return await task;
        }
    }
}
