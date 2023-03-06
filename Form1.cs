using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;

namespace IMGIMP
{
    public partial class Form1 : Form
    {
        #region 初始化
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //progressBar2.Value = 30;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //progressBar1.Value = 30;
        }
        #endregion

        string openPath;
        string savePath;
        private void button1_Click_1(object sender, EventArgs e)
        {

            bool open = OpenFileDialog("C://", "Imgage files|*.png;*.jpg*.jpeg;*.webp;*.bmp", out openPath);
            if (open)
            {
                bool save = SaveFileDialog(Path.GetDirectoryName(openPath), "Imgage files|*.png;*.jpg*.jpeg;*.webp;*.bmp", out savePath);
                if (save)
                {
                    Generate();
                }
                else
                {
                    return;
                    //选择正确保存路径
                }
            }
            else
            {
                return;
                //选择正确的图片
            }
        }
        string Modify(string x)
        {
            return "\"" + x + "\"";
        }
        class AAA
        {
            void Print() { }
        }
        private void Generate()
        {
            Process process = new Process();
            string p = $"-i {Modify(openPath)} -o {Modify(savePath)} -n {map[selector]}";
            ProcessStartInfo startInfo = new ProcessStartInfo("realesrgan-ncnn-vulkan.exe", p);

            process.StartInfo = startInfo;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = false;

            process.Start();

            async void Complete()
            {
                await process.WaitForExitAsync();
                process.Kill();
            }
            Complete();

            () =>
            {
                int a;
            }
        }
        #region 调用Win文件路径选择和保存
        private bool SaveFileDialog(string init, string filter, out string path)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = init;

            saveFileDialog.Filter = $"{filter}|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;

                return true;
            }

            path = string.Empty;
            return false;
        }
        private bool OpenFileDialog(string init, string filter, out string path)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = init;
            openFileDialog1.Filter = $"{filter}|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;

                return true;
            }

            path = string.Empty;
            return false;
        }

        #endregion

        #region 模型选项
        int selector = 1;
        Dictionary<int, string> map = new Dictionary<int, string>()
        {
            {1,"realesrgan-x4plus" },
            {2,"realesrgan-x4plus-anime" },
            {3,"realesr-animevideov3" }
        };
        //选项1
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selector = 2;
        }
        //选项2
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            selector = 1;
        }
        //选项3
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            selector = 3;
        }

        #endregion

        #region UI回调
        //进度条
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        //进度值
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}