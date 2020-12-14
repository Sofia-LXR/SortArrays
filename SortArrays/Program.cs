using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 26, 15, 27, 34, 59, 67, 81 };
            Console.WriteLine("排序数组为" + String.Join(",", arr));
            BubbleSort(arr);
            SelectionSort(arr);
            InsertionSort(arr);
            MergeSort(arr);
            ShellSort(arr);
            QuickSort(arr);
            Console.ReadKey();
        }

        /// <summary>
        /// 交换方法
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            //借助中间值交换ab值
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        private static void BubbleSort(int[] arr)
        {
            Console.WriteLine("\n--冒泡排序--");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                    }
                }
                //Console.WriteLine("第" + (i + 1) + "次排序" + String.Join(",", arr));
            }
            Console.WriteLine("\n冒泡排序结果为：" + String.Join(",", arr));
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        private static void SelectionSort(int[] arr)
        {

            Console.WriteLine("\n--选择排序--");
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                Swap(ref arr[i], ref arr[min]);
                //Console.WriteLine("第" + (i + 1) + "次排序结果为" + String.Join(",", arr));
            }
            Console.WriteLine("\n选择排序结果为：" + String.Join(",", arr));
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        private  static void InsertionSort(int[] arr)
        {
            Console.WriteLine("\n--插入排序--");
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
                //合并写法
                //for (int j = i - 1; j >= 0 && arr[j] > arr[j + 1]; j--)
                //{
                //    Swap(ref arr[j], ref arr[j + 1]);
                //}
                //Console.WriteLine("第" + i + "次排序结果为" + String.Join(",", arr));
            }
            Console.WriteLine("\n插入排序结果为：" + String.Join(",", arr));
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="array"></param>
        static void MergeSort(int[] array)
        {
            Console.WriteLine("\n----归并排序----");
            MergeSort(array, 0, array.Length - 1);
            Console.WriteLine("\n归并排序结果为：" + String.Join(",", array));
        }
        static void MergeSort(int[] arry, int low, int high)
        {
            if (low < high)
            {
                //这里利用归并排序，将数组分成两个元素为一组的最小序列
                int mid = (low + high) / 2;
                MergeSort(arry, low, mid);
                MergeSort(arry, mid + 1, high);
                Merge(arry, low, mid, high);
            }
        }
        //归并排序算法主体
        private static void Merge(int[] arry, int low, int mid, int high)
        {
            int[] newArray = new int[high - low + 1];//创建一个新的数组长度是low到high的元素个数
            int left = low; //拿到左边数组的开始索引
            int right = mid + 1; //到右边数组的开始索引
            int index = 0; //新数组的索引
            while (left <= mid && right <= high)
            {
                //左右两边数组,相同索引比较,将较小值的放入新数组，这里需要考虑相等的情况，
                //直到一个数组放完，跳出循环
                if (arry[left] <= arry[right])
                {
                    newArray[index++] = arry[left++];
                }
                else
                {
                    newArray[index++] = arry[right++];
                }
            }
            //那边数组没有放完，接着依次放进去。
            while (left <= mid)
            {
                newArray[index++] = arry[left++];
            }
            while (right <= high)
            {
                newArray[index++] = arry[right++];
            }
            index = 0;
            while (low <= high)
            {
                //最后依次将新数组的值放回原来的数组排序完成
                arry[low++] = newArray[index++];
            }
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left">数组的0下标</param>
        /// <param name="right">数组的Length - 1下标</param>
        private static void QuickSort(int[] arr)
        {
            Console.WriteLine("\n----快速排序----");
            int left = 0;
            int right = arr.Length - 1;
            if (left < right)
            {
                int L = left;
                int R = right;
                int pivot = arr[L];
                while (L < R)
                {
                    //从后向前找出比pivot小的数
                    while (L < R && arr[R] > pivot)
                    {
                        R--;
                    }
                    //找到比pivot小的数，赋值给arr[L]
                    if (L < R)
                    {
                        arr[L] = arr[R];
                        L++;
                    }
                    //从前向后找出比pivot大的数
                    while (L < R && arr[L] < pivot)
                    {
                        L++;
                    }
                    //找到比pivot大的数，赋值给arr[R], 也就是之前比pivot小的数的位置
                    if (L < R)
                    {
                        arr[R] = arr[L];
                        R--;
                    }
                }
            }
            Console.WriteLine("\n快速排序结果为：" + String.Join(",", arr));
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="arr"></param>
        public static void ShellSort(int[] arr)
        {
            Console.WriteLine("\n----希尔排序----");
            int d = arr.Length / 2;
            while (d >= 1)
            {
                for (int i = 0; i < d; i++)
                {
                    for (int j = i + d; j < arr.Length; j += d)
                    {
                        int temp = arr[j];//存储和其比较的上一个a[x];
                        int loc = j;
                        while (loc - d >= i && temp < arr[loc - d])//&&j-d>=i
                        {
                            arr[loc] = arr[loc - d];
                            loc = loc - d;
                        }
                        arr[loc] = temp;
                    }
                }
                //一次插入排序结束，缩小d的值
                d = d / 2;
            }
            Console.WriteLine("\n希尔排序结果为：" + String.Join(",", arr));
        }
    }

}
