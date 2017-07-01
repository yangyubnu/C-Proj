

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
                bool bAscending = t == SortTest.SortType.Ascending;

                for (int j = 0; j < array.Length; j++)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        if (bAscending)
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

                return array;
            }

            //插入排序
            //每个数插入到正确的位置
            //从第一个值往前一个个排查，直到把当前值插入到正确的位置
            public int[] InsertSort(int[] array, SortType t = SortType.Ascending)
            {
                bool bAscending = t == SortTest.SortType.Ascending;

                for (int i = 0; i < array.Length; i++)
                {
                    int insertValue = array[i];
                    int insertIndex = i - 1;

                    if (bAscending)
                    {
                        //升序
                        //下标大于等于0并且当前值比前面的值小的时，把前面的值往后面诺一个，下标往前进一个，直到不满足上面的情况的时候跳出循环
                        while (insertIndex >= 0 && insertValue < array[insertIndex])
                        {
                                array[insertIndex + 1] = array[insertIndex];
                                insertIndex--;
                        }

                        //下标所在位置值已经比当前值小了，所以是在当前下表位的后一位
                        array[insertIndex + 1] = insertValue;
                    }
                    else
                    {
                        while (insertIndex >= 0 && insertValue > array[insertIndex])
                        {
                                array[insertIndex + 1] = array[insertIndex];
                                insertIndex--;
                        }

                        array[insertIndex + 1] = insertValue;
                    }
                }
                    
                return array;
            }

            //快速排序
            //需要找一个基准值，然后以基准值为分解，把大于小于基准值的数字分开
            //然后再重复上面步奏（递归），直到排序完成
            public void QuickSort(int[] array, SortType t = SortType.Ascending)
            {
                bool bAscending = t == SortType.Ascending;

                QSort(array, 0, array.Length - 1, bAscending);
                //print("array", array.ToString());
            }

            void QSort(int[] array, int low, int high, bool bAscending) 
            {
                int pivot = 0;

                //出口
                if (low < high)
                {
                    pivot = Partiton(array, low, high, bAscending);

                    QSort(array, low, pivot - 1, bAscending);
                    QSort(array, pivot + 1, high, bAscending);
                }
            }

            //获得基准值，并且重新分配数组
            int Partiton(int[] array, int low, int high, bool bAscending)
            {
                int leftIndex = low;
                int rightIndex = high;
                int pivotKey = array[low];

                if (bAscending)
                {
                    while (leftIndex < rightIndex)
                    {
                        //当左边下标小于右边下标且，右边下标所在值大于基准值的时候，不用换位置，所以下标往前-1，直到找到一个小于基准值的值，停下来
                        while (leftIndex < rightIndex && array[rightIndex] >= pivotKey)
                            rightIndex--;

                        //直接把右边的换到左边
                        Swap(array, leftIndex, rightIndex);

                        //print("-------------------leftIndex:{0}, pivotKey:{1}", leftIndex, pivotKey);
                        //PrintArray("array:{0}", a);

                        //当左边下标小于右边下标且，左边下标所在值小于基准值的时候，不用换位置，所以下标往后+1，直到找到一个大于基准值的值，停下来
                        while (leftIndex < rightIndex && array[leftIndex] <= pivotKey)
                            leftIndex++;

                        //直接把左边的换到右边
                        Swap(array, leftIndex, rightIndex);

                        //因为换到左边右边的值都会再过一次当前下标的检查，且如果满足条件会改变下标的值，所以可以保证循环结束，全部的值归位

                        //print("-------------------leftIndex:{0}, pivotKey:{1}", leftIndex, pivotKey);
                        //PrintArray("array:{0}", a);
                    }
                }
                else
                {
                    while (leftIndex < rightIndex)
                    {
                        while (leftIndex < rightIndex && array[rightIndex] <= pivotKey)
                            rightIndex--;

                        Swap(array, leftIndex, rightIndex);

                        while (leftIndex < rightIndex && array[leftIndex] >= pivotKey)
                            leftIndex++;

                        Swap(array, leftIndex, rightIndex);
                    }            
                }

                //PrintArray(array);

                return leftIndex;
            }

            //简单选择排序
            //找出最小的与第一个数交换，找出次小的跟第二个数交换
            public void SimpleSelectSort(int[] array, SortType t = SortType.Ascending)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int min = array[i];
                    int minIndex = i;

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (min > array[j])
                        {
                            min = array[j];
                            minIndex = j;
                        }
                    }

                    if (i != minIndex)
                        Swap(array, i, minIndex);
                }
            }

            void Swap(int[] array, int a, int b) 
            {
                int num = array[a];
                array[a] = array[b];
                array[b] = num;
            }

            void PrintArray(int[] array)
            {
                string a = "";
                for (int i = 0; i < array.Length; i++)
                    a = a + array[i].ToString() + " ";

                print("array:{0}", a);
            }
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("hello world!");
            int[] myArray = new int[] { 45, 36, 36, 18, 53, 72, 30, 48, 93, 15};

            SortFunc sf = new SortFunc();

            //排序
            //sf.BubbleSort(myArray, SortType.Ascending);
            //sf.InsertSort(myArray, SortType.Descending);
            //sf.QuickSort(myArray, SortType.Ascending);
            sf.SimpleSelectSort(myArray, SortType.Ascending);

            //print("myArray.Length{0}", myArray.Length);

            for (int i = 0; i < myArray.Length; i++)
            {
                print("{0}", myArray[i]);
            }
            
            System.Console.ReadLine();
        }

        public static void print(string log, params object[] args)
        {
            System.Console.WriteLine(log, args);
        }
    }
}
