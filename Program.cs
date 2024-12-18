﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace prj_system_address
{
    internal class Program
    {

        static int datatype_count(int i)//識別資料型態
        { int count = i;
            int dt_size;
            switch (count)
            {
                case 1:
                    dt_size = 4;
                    break;
                case 2:
                    dt_size = 1;
                    break;
                case 3:
                    dt_size = 4;
                    break;
                    case 4:
                    dt_size = 8;
                    break;
                default:
                    dt_size = 0; // 或者其他適當的默認值
                    break;
            }
            return dt_size;
        }
        static void reprint(int end)
        {
            Console.Write($"位置在{end}");
        }
        static void Main(string[] args)
        { 
            Console.Write("請輸入陣列資料型態(1)int、(2).char、(3)float、(4)double：");
            int data_type=Convert.ToInt32(Console.ReadLine());
           int arry_byte=datatype_count(data_type);//byte
            Console.Write("請輸入陣列名稱：");
            string arry_name = Console.ReadLine();
            Console.Write($"請輸入陣列：{arry_name}維度，(至多不超過5維陣列)：");
            int arry_index =Convert.ToInt32(Console.ReadLine());//維度數
            int[] arry_size = new int[arry_index];//存放各維度大小
            int[] search_address = new int[arry_index];//存放索引值位置
            if (arry_index <= 5)
                {
                    for (int i = 0; i < arry_index; i++)
                    {
                        Console.Write($"請輸入第{i + 1}維度大小：");
                        arry_size[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write("請輸入記憶體存放方式(1)以列為主、(2)以行為主");
                    int save_method =Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < arry_index; i++)
                    {
                        Console.Write($"請輸入您在第{i + 1}維度要找的索引值維(0~{arry_size[i] - 1})");
                        search_address[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write($"請輸入{arry_name}陣列第一個元素的起始位置：");
                    int start_address = Convert.ToInt32(Console.ReadLine());
                    int total = 0;
                    int[] temp_space = new int[arry_index];
                    if (save_method == 1)//列為主
                    {
                        for (int i = 0; i < search_address.Length; i++)//上排
                        {
                            for (int j = i++; j < arry_size.Length; j++)//下排
                            {
                            temp_space[i] *= arry_size[j ];
                        }
                        total += temp_space[i] * search_address[i];
                        
                            while (i == (search_address.Length - 1))
                            {
                                total += search_address[i];
                                total += start_address;//加總完
                            break;
                            }
                        }
                    reprint(total);
                    Console.ReadKey();
                    }
                    else //行為主
                    { int temp_total = 1;
                    int[] save_total = new int[search_address.Length];
                    for (int i = search_address.Length; i>=1; i--)
                    {
                        for (int j = arry_size.Length-1; j >= 0; j--)
                        {
                            temp_total *= arry_size[j];

                        }
                        save_total[i] = temp_total;
                    }
                    save_total[0] = search_address[0];

                    for (int i = 0; i < search_address.Length;i++)
                    {
                        total += save_total[i];
                    }
                    int final = start_address + total;
                    reprint(final);
                    }
                }
            else//
                {
                    Console.Write($"{arry_name}陣列超過5維度!");
                    Console.Write($"請重新輸入{arry_name}陣列維度：");
                    int arry_index2 = Convert.ToInt32(Console.ReadLine());
                    arry_index = arry_index2;
                   
                }
        }
    }
}
