using System;
using System.Windows;
using System.Windows.Input;

namespace Base64Decoder
{
    public partial class MainWindow : Window
    {
        public AsyncObservableCollection<LogModel> Logs;
        public MainWindow()
        {
            InitializeComponent();
            Reset();
            lst_logs.ItemsSource = Logs;
        }

        #region Helpers

        private void Reset()
        {
            txt_raw.Clear();
            txt_result.Clear();
            Logs = new AsyncObservableCollection<LogModel>();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e) { }

        private void btn_moveDown_Click(object sender, RoutedEventArgs e)
        {
            txt_result.Text = txt_raw.Text;
        }

        private void btn_moveUp_Click(object sender, RoutedEventArgs e)
        {
            txt_raw.Text = txt_result.Text;
        }

        private void btn_swap_Click(object sender, RoutedEventArgs e)
        {
            string temp = txt_raw.Text;
            txt_raw.Text = txt_result.Text;
            txt_result.Text = temp;
        }

        private void btn_resultClear_Click(object sender, RoutedEventArgs e)
        {
            txt_result.Clear();
        }

        private void btn_result_copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txt_result.Text);
        }

        private void btn_rawClear_Click(object sender, RoutedEventArgs e)
        {
            txt_raw.Clear();
        }

        private void AddLog(string raw, string result, bool isDecode)
        {
            Logs.Add(new LogModel()
            {
                IsDecode = isDecode,
                Raw = raw,
                Result = result
            });
        }

        #endregion Helpers

        private void btn_encode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var raw = txt_raw.Text;
                var result = Encoder.Encode(raw);

                txt_result.Text = result;
                AddLog(raw, result, isDecode: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not encode the text entered. details: {ex}", "Error happened", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btn_decode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var raw = txt_raw.Text;
                if (Base64Validator.IsValid(raw) == false)
                    MessageBox.Show("Entered text is not a valid base64. will try to decode but it might not be successful.",
                        "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);

                raw = Base64Transformer.TransformBase64(raw);

                var arrRaw = Base64Transformer.SeparateByPipeBase64(raw);

                foreach (var itemRaw in arrRaw)
                {
                    var result = Decoder.Decode(itemRaw);
                    txt_result.Text = result;
                    AddLog(raw, result, isDecode: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not encode the text entered. details: {ex}", "Error happened", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void lst_logs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var selectedItem = lst_logs.SelectedItem;
                var item = (LogModel)selectedItem;
                if (item != null)
                {
                    if (rdb_raw.IsChecked == true)
                        Clipboard.SetText(item.Raw);
                    else if (rdb_result.IsChecked == true)
                        Clipboard.SetText(item.Result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not complete the operation. details: {ex}", "Error happened", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
