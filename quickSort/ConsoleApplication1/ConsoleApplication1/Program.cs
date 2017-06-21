

namespace SortTest
{
    class SortTest
    {
        public enum SortType
        {
            Ascending = 0,//升序
            Descending = 1,//降序
        };

        public class SortFunc
        {
            public int a = 0;
            public int b = 0;

            //冒泡排序
            //一轮比出一个最
            public int[] BubbleSort(int[] array, SortType t = SortType.Ascending)
            {
                bool bType = t == SortTest.SortType.Ascending;
                int count = 0;

                for (int j = 0; j < array.Length; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        count++;

                        if (bType)
                        {
                            if (array[i] > array[i + 1])
                            {
                                int num = array[i + 1];
                                array[i + 1] = array[i];
                                array[i] = num;
                            }
                        }
                        else
                        {
                            if (array[i] < array[i + 1])
                            {
                                int num = array[i + 1];
                                array[i + 1] = array[i];
                                array[i] = num;
                            }
                        }
                    }
                }

                print("count{0}", count);
                return array;
            }

            //插入排序
            //每个数插入到正确的位置
            public int[] InsertSort(int[] array, SortType t = SortType.Ascending)
            {
                bool bType = t == SortTest.SortType.Ascending;
                int count = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j > 0; j--)
                    {
                        count++;

                        if (bType)
                        {
                            if (array[j] < array[j - 1])
                            {
                                int num = array[j - 1];
                                array[j - 1] = array[j];
                                array[j] = num;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (array[j] > array[j - 1])
                            {
                                int num = array[j - 1];
                                array[j - 1] = array[j];
                                array[j] = num;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                print("count{0}", count);
                return array;
            }

            //快速排序
            public void QuickSort(int[] array)
            {
                string a = "";
                for (int i = 0; i < array.Length; i++)
                    a = a + array[i].ToString() + " ";

                print("array:{0}", a);

                QSort(array, 0, array.Length - 1);
                print("array", array.ToString());
            }

            void QSort(int[] array, int low, int high) 
            {
                int pivot = 0;
                if (low < high)
                {
                    pivot = Partiton(array, low, high);

                    QSort(array, low, pivot - 1);
                    QSort(array, pivot + 1, high);
                }
            }

            int Partiton(int[] array, int low, int high)
            {
                int leftIndex = low;
                int rightIndex = high;
                int pivotKey = array[low];

                while (leftIndex < rightIndex)
                {
                    while (leftIndex < rightIndex && array[rightIndex] >= pivotKey)
                        rightIndex--;

                    Swap(array, leftIndex, rightIndex);

                    string a = "";
                    for (int i = 0; i < array.Length; i++)
                        a = a + array[i].ToString() + " ";

                    print("-------------------leftIndex:{0}, pivotKey:{1}", leftIndex, pivotKey);
                    print("array:{0}", a);

                    while (leftIndex < rightIndex && array[leftIndex] <= pivotKey)
                        leftIndex++;

                    Swap(array, leftIndex, rightIndex);

                    a = "";
                    for (int i = 0; i < array.Length; i++)
                        a = a + array[i].ToString() + " ";

                    print("-------------------leftIndex:{0}, pivotKey:{1}", leftIndex, pivotKey);
                    print("array:{0}", a);
                    //if (leftIndex < rightIndex)
                    //    Swap(array, leftIndex, rightIndex);
                }

                string b = "";
                for (int i = 0; i < array.Length; i++)
                    b = b + array[i].ToString() + " ";

                print("================================");
                print("array:{0}", b);

                return leftIndex;
                /*
                int temp = pivotKey;
                if (temp < array[rightIndex])
                {
                    array[low] = array[rightIndex - 1];
                    array[rightIndex - 1] = temp;
                    return rightIndex - 1;
                }
                else
                {
                    array[low] = array[rightIndex];
                    array[rightIndex] = temp;
                    return rightIndex;
                }*/

            }

            void Swap(int[] array, int a, int b) 
            {
                int num = array[a];
                array[a] = array[b];
                array[b] = num;
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("hello world!");
            int[] myArray = new int[] { 45, 36, 18, 53, 72, 30, 48, 93, 15};
            //myArray = new int[] { 3, 4, 5, 1};
            //myArray = new int[] { 3, 4, 2, 1};

            SortFunc sf = new SortFunc();
            print("hello!");
            print("1." + sf.a);
            sf.a = 10;
            print("2.{0}", sf.a.ToString());

            //排序
            //int[] ary = sf.BubbleSort(myArray, SortType.Ascending);
            //int[] ary = sf.InsertSort(myArray, SortType.Descending);
            sf.QuickSort(myArray);

            print("myArray.Length{0}", myArray.Length);

            for (int i = 0; i < myArray.Length; i++)
            {
                print("{0}", myArray[i]);
            }
            
            while (true) ;
        }

        public static void print(string log, params object[] args)
        {
            System.Console.WriteLine(log, args);
        }
    }
}
