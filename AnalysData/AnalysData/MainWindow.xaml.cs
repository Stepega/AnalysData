using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Collections.ObjectModel;

namespace AnalysData
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string path = @"C:\new\mycsv.csv";
        //StreamReader csv = new StreamReader(path, Encoding.UTF8);
        char[] delimiterChars = { ' ', ',', ':' };
        List<Data> dataList = new List<Data>();
        List<Data> diskDataList = new List<Data>();
        bool firstLine = false;
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            //string path = @"C:\new\mycsv.csv";
            StreamReader csv = new StreamReader(path, Encoding.UTF8);
            //char[] delimiterChars = { ' ', ',', ':' };
            //List<Data> dataList = new List<Data>();
            //bool firstLine = false;
            //int count = 0;
            while (!csv.EndOfStream)
            {
                string str;
                str = csv.ReadLine();
                string[] splitStr = str.Split(delimiterChars);
                if (firstLine)
                {
                    count++;
                    string date1 = splitStr[0];
                    double numberOne1 = Convert.ToDouble(splitStr[4].Replace(".", ","));
                    double numberTwo1 = Convert.ToDouble(splitStr[5].Replace(".", ","));
                    dataList.Add(new Data(count, splitStr[0], splitStr[1], splitStr[2], splitStr[3], numberOne1, numberTwo1));
                }
                firstLine = true;
            }
            #region Sort


            dataList.Sort(delegate (Data temp1, Data temp2)
            { return temp1.sortID.CompareTo(temp2.sortID); });




            #endregion

            ResponseTotalChart.Clear();



            count = 0;
            foreach (Data outData in dataList)
            {
                count++;
                outData.id = count;
                outData.date = outData.timeFormat.ToString("F");
                //((ArrayList)DataList.Resources["DataListView"]).Add(outData);
            }
            //DataList.Items.Refresh();
        }
        public class ResponsePoint
        {
            public double x { get; set; }
            public double y { get; set; }
            public double y2 { get; set; }
            public DateTime x2 { get; set; }
        }
        public ObservableCollection<ResponsePoint> ResponseTotalChart { get; set; } = new ObservableCollection<ResponsePoint>();
        public ObservableCollection<ResponsePoint> ResponseTotalChartDelta { get; set; } = new ObservableCollection<ResponsePoint>();
        public ObservableCollection<ResponsePoint> ResponseTotalChartPlot { get; set; } = new ObservableCollection<ResponsePoint>();
        public class Data
        {
            public int id { get; set; }
            public string date { get; set; }
            public int dateYear { get; set; }
            public int dateMonth { get; set; }
            public int dateDay { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
            public int second { get; set; }
            public double numberOne { get; set; }
            public double numberTwo { get; set; }
            public int sortID { get; set; }
            public DateTime timeFormat { get; set; }

            public static int sortData(string date, string hour, string minute, string second)
            {
                int temp;
                string str = /*Convert.ToString(GetYear(date)) + Convert.ToString(GetMonht(date)) +*/ Convert.ToString(GetDay(date)) + hour + minute + second;
                temp = Convert.ToInt32(str);
                return temp;
            }
            public static int GetMonht(string date)
            {
                string[] splitDate = date.Split('-');
                int month = 0;
                month = Convert.ToInt32(splitDate[1]);
                return month;
            }
            public static int GetYear(string date)
            {
                string[] splitDate = date.Split('-');
                int year = 0;
                year = Convert.ToInt32(splitDate[0]);
                return year;
            }
            public static int GetDay(string date)
            {
                string[] splitDate = date.Split('-');
                int day = 0;
                day = Convert.ToInt32(splitDate[2]);
                return day;
            }
            public Data(int id, DateTime timeFormat, double numberOne, double numberTwo)
            {
                this.id = id;
                this.timeFormat = timeFormat;
                this.numberOne = numberOne;
                this.numberTwo = numberTwo;
            }
            public Data(int id, string date, string hour, string minute, string second, double numberOne, double numberTwo)
            {
                this.id = id;
                this.date = date;
                this.hour = Convert.ToInt32(hour);
                this.minute = Convert.ToInt32(minute);
                this.second = Convert.ToInt32(second);
                this.numberOne = numberOne;
                this.numberTwo = numberTwo;
                dateDay = GetDay(date);
                sortID = sortData(date, hour, minute, second);
                timeFormat = new DateTime(GetYear(date), GetMonht(date), GetDay(date), Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));

            }



        }
        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChart.Clear();
            ChartOne.Title = "День " + inputData.Text;
            int day = 1;
            int hour = 0;
            int count = 0;
            day = Convert.ToInt32(inputData.Text);
            hour = dataList[0].hour;
            foreach (Data outData in dataList)
            {
                if (day == outData.dateDay)
                {
                    if (hour == outData.hour)
                        count++;
                    else
                    {
                        ResponseTotalChart.Add(new ResponsePoint
                        {
                            x = hour,
                            y = count,
                        });
                        hour = outData.hour;
                        count = 0;
                    }
                }

            }
            ChartOne.ItemsSource = ResponseTotalChart;
        }
        private void HourButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChart.Clear();
            ChartOne.Title = "День " + inputData.Text + " Час " + inputHour.Text;
            int day = 1;
            int hour = 0;
            int count = 0;
            int minute = 0;
            day = Convert.ToInt32(inputData.Text);
            hour = Convert.ToInt32(inputHour.Text);
            foreach (Data outData in dataList)
            {
                if (day == outData.dateDay)
                {
                    if (hour == outData.hour)
                    {
                        if (minute == outData.minute)
                            count++;
                        else
                        {
                            ResponseTotalChart.Add(new ResponsePoint
                            {
                                x = minute,
                                y = count,
                            });
                            minute = outData.minute;
                            count = 0;

                        }
                    }
                }

            }
            ChartOne.ItemsSource = ResponseTotalChart;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void FreqButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChart.Clear();
            ChartOne.Title = "Частота1";
            int[] number = new int[1];
            int[] count = new int[1];
            number[0] = Convert.ToInt32(diskDataList[0].numberOne);
            count[0] = 1;
            bool dop = true;
            foreach (Data outData in diskDataList)
            {
                dop = true;
                for (int i = 0; i < number.Length; i++)
                    if (Convert.ToInt32(outData.numberOne) == number[i])
                    {
                        count[i]++;
                        dop = false;
                    }
                if (dop)
                {
                    int temp;
                    temp = number.Length + 1;
                    Array.Resize(ref number, temp);
                    temp = count.Length + 1;
                    Array.Resize(ref count, temp);
                    number[number.Length - 1] = Convert.ToInt32(outData.numberOne);
                    count[count.Length - 1] = 1;
                }

            }

            for (int i = 0; i < number.Length; i++)
            {
                ResponseTotalChart.Add(new ResponsePoint
                {
                    x = number[i],
                    y = count[i],
                });
            }
            ChartOne.ItemsSource = ResponseTotalChart;
        }
        private void Freq2Button_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChart.Clear();
            ChartOne.Title = "Частота2";
            int[] number = new int[1];
            int[] count = new int[1];
            number[0] = Convert.ToInt32(diskDataList[0].numberTwo);
            count[0] = 1;
            bool dop = true;
            foreach (Data outData in diskDataList)
            {
                dop = true;
                for (int i = 0; i < number.Length; i++)
                    if (Convert.ToInt32(outData.numberTwo) == number[i])
                    {
                        count[i]++;
                        dop = false;
                    }
                if (dop)
                {
                    int temp;
                    temp = number.Length + 1;
                    Array.Resize(ref number, temp);
                    temp = count.Length + 1;
                    Array.Resize(ref count, temp);
                    number[number.Length - 1] = Convert.ToInt32(outData.numberTwo);
                    count[count.Length - 1] = 1;
                }

            }

            for (int i = 0; i < number.Length; i++)
            {
                ResponseTotalChart.Add(new ResponsePoint
                {
                    x = number[i],
                    y = count[i],
                });
            }
            ChartOne.ItemsSource = ResponseTotalChart;
        }
        private void DeltaButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChartPlot.Clear();
            int[] diskret = new int[1];
            int[] count = new int[1];
            bool dop = true;
            int temp;
            for (int i = 1; i < dataList.Count; i++)
            {
                dop = true;
                temp = dataList[i].timeFormat.Second - dataList[i - 1].timeFormat.Second;
                if (temp < 0)
                    temp = temp + 60;
                for (int j = 0; j < diskret.Length; j++)
                    if (temp == diskret[j])
                    {
                        count[j]++;
                        dop = false;
                    }
                if (dop)
                {
                    int tempdop;
                    tempdop = diskret.Length + 1;
                    Array.Resize(ref diskret, tempdop);
                    tempdop = count.Length + 1;
                    Array.Resize(ref count, tempdop);
                    diskret[diskret.Length - 1] = temp;
                    count[count.Length - 1] = 1;
                }
            }
            for (int i = 0; i < diskret.Length; i++)
            {
                ResponseTotalChartPlot.Add(new ResponsePoint
                {
                    x = diskret[i],
                    y = count[i],
                });
            }
            ChartPlot.ItemsSource = ResponseTotalChartPlot;
            ChartPlot.Title = "Плотн";

            #region Disecretnost'
            int maxCount = 0;
            int rememberI = 0;
            for (int i = 0; i < diskret.Length; i++)
            {
                if (count[i] > maxCount)
                {
                    maxCount = count[i];
                    rememberI = i;
                }
            }
            if (diskret[rememberI] == 0 || diskret[rememberI] == 1) diskret[rememberI] = 2;
            diskDataList.Add(new Data(dataList[0].id, dataList[0].timeFormat, dataList[0].numberOne, dataList[0].numberTwo));
            DateTime tempDate = diskDataList[0].timeFormat;
            tempDate = tempDate.AddSeconds(diskret[rememberI]);
            //while (true)
            //{
            //    bool search = true;
            //    if (tempDate >= dataList[dataList.Count - 1].timeFormat) break;
            for (int i = 1; i < dataList.Count - 1; i++)
            {
                if (tempDate >= dataList[dataList.Count - 1].timeFormat) break;
                if (tempDate == dataList[i].timeFormat)
                {

                    //foreach (Data checklist in diskDataList)
                    //{
                    //    if (checklist.timeFormat == tempDate) check = false;
                    //}
                    if (dataList[i].timeFormat != dataList[i - 1].timeFormat)
                    {
                        diskDataList.Add(new Data(dataList[i].id, tempDate, dataList[i].numberOne, dataList[i].numberTwo));
                        tempDate = tempDate.AddSeconds(diskret[rememberI]);
                    }
                    //average = false;
                    //search = false;
                    //break;
                }
                else
                {

                    double temp1 = (dataList[i].numberOne  + dataList[i + 1].numberOne) / 2;
                    double temp2 = (dataList[i].numberTwo + dataList[i + 1].numberTwo) / 2;
                    double temp12 = (dataList[i].numberOne + dataList[i - 1].numberOne) / 2;
                    double temp22 = (dataList[i].numberTwo + dataList[i - 1].numberTwo) / 2;
                    //foreach (Data checklist in diskDataList)
                    //{
                    //if (checklist.timeFormat == tempDate) check = false;
                    //}

                    if (tempDate > dataList[i].timeFormat)
                    {
                        diskDataList.Add(new Data(dataList[i].id, tempDate, temp1, temp2));
                        tempDate = tempDate.AddSeconds(diskret[rememberI]);
                    }
                    if (tempDate < dataList[i].timeFormat)
                    {
                        diskDataList.Add(new Data(dataList[i].id, tempDate, temp12, temp22));
                        tempDate = tempDate.AddSeconds(diskret[rememberI]);
                        i--;
                    }

                    //average = false;
                    //search = false;
                    //break;
                }



            }
            //if (search)
            //{
            //    tempDate = tempDate.AddSeconds(1);
            //    average = true;
            //}

            //}

            //diskDataList.Sort(delegate (Data temp1, Data temp2)
            //{ return temp1.timeFormat.CompareTo(temp2.timeFormat); });

            //inputData.Text = Convert.ToString(diskDataList.Count);
            int countId = 0;
            foreach (Data outData in diskDataList)
            {
                countId++;
                outData.id = countId;
                outData.date = outData.timeFormat.ToString("F");
                ((ArrayList)DataList.Resources["DataListView"]).Add(outData);
            }
            DataList.Items.Refresh();

            #endregion
            #region graficdrow
            
            #endregion
        }
        private void Delta2Button_Click(object sender, RoutedEventArgs e)
        {
            ResponseTotalChartDelta.Clear();

            bool startDraw = false;
            int startDay = Convert.ToInt32(viewstartDay.Text);
            int startHour = Convert.ToInt32(viewstartHour.Text);
            int startMinute = Convert.ToInt32(viewstartMinute.Text);
            int endDay = Convert.ToInt32(viewendDay.Text);
            int endHour = Convert.ToInt32(viewendHour.Text);
            int endMinute = Convert.ToInt32(viewendMinute.Text);
            for (int i = 0; i < diskDataList.Count; i++)
            {
                if (diskDataList[i].timeFormat.Day == startDay && diskDataList[i].timeFormat.Hour == startHour && diskDataList[i].timeFormat.Minute == startMinute)
                    startDraw = true;
                if (diskDataList[i].timeFormat.Day == endDay && diskDataList[i].timeFormat.Hour == endHour && diskDataList[i].timeFormat.Minute == endMinute)
                    startDraw = false;
                if (startDraw)
                {
                    ResponseTotalChartDelta.Add(new ResponsePoint
                    {
                        x2 = diskDataList[i].timeFormat,
                        y = diskDataList[i].numberOne,
                        y2 = diskDataList[i].numberTwo,
                    });
                }
            }
            //dataList[4].timeFormat = dataList[4].timeFormat.AddSeconds(58);
            //inputData.Text = Convert.ToString(diskDataList[4].timeFormat);
            CharDelta1.ItemsSource = ResponseTotalChartDelta;
            CharDelta2.ItemsSource = ResponseTotalChartDelta;
            CharDelta1.Title = "Параметр1";
            CharDelta2.Title = "Параметр2";

        }
    }
}
