using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab01_02
{
    class Program
    {
        static void Main()
        {
            List<Student> studentList = new List<Student>();

            while (true)
            {
                Console.WriteLine("=== MENU QUAN LY SINH VIEN ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach sinh vien");
                Console.WriteLine("3. Xuat sinh vien thuoc khoa CNTT");
                Console.WriteLine("4. Xuat sinh vien co diem TB tu 5 tro len");
                Console.WriteLine("5. Xuat danh sach theo diem TB tang dan");
                Console.WriteLine("6. Xuat sinh vien khoa CNTT co diem TB tu 5 tro len");
                Console.WriteLine("7. Xuat sinh vien co diem TB cao nhat khoa CNTT");
                Console.WriteLine("8. Dem so sinh vien theo tung xep loai");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;

                    case "2":
                        DisplayStudentList(studentList);
                        break;

                    case "3":
                        DisplayStudentList(studentList.Where(IsCNTT));
                        break;

                    case "4":
                        DisplayStudentList(studentList.Where(s => s.AverageScore >= 5));
                        break;
                    case "5":
                        DisplayStudentList(studentList.OrderBy(s => s.AverageScore));
                        break;

                    case "6":
                        DisplayStudentList(studentList.Where(s =>
                            IsCNTT(s) && s.AverageScore >= 5));
                        break;
                    case "7":
                        DisplayTopCNTTStudents(studentList);
                        break;

                    case "8":
                        CountByGrade(studentList);
                        break;
                    case "0":
                    case null:
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== NHAP THONG TIN SINH VIEN ===");

            Student student = new Student();
            student.Input();
            studentList.Add(student );
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void DisplayStudentList(IEnumerable<Student> students)
        {
            Console.WriteLine("=== DANH SACH SINH VIEN ===");
            bool hasStudent = false;

            foreach (Student student in students)
            {
                student.Show();
                hasStudent = true;
            }

            if (!hasStudent)
            {
                Console.WriteLine("Khong co sinh vien de hien thi.");
            }
        }

        static bool IsCNTT(Student student)
        {
            return string.Equals(student.Faculty, "CNTT",
                StringComparison.OrdinalIgnoreCase);
        }

        static void DisplayTopCNTTStudents(List<Student> studentList)
        {
            var sinhVienCNTT = studentList.Where(IsCNTT).ToList();

            if (sinhVienCNTT.Count == 0)
            {
                Console.WriteLine("Khong co sinh vien khoa CNTT.");
                return;
            }
            float diemCaoNhat = sinhVienCNTT.Max(s => s.AverageScore);
            DisplayStudentList(sinhVienCNTT.Where(s => s.AverageScore == diemCaoNhat));
        }
        static void CountByGrade(List<Student> studentList)
        {
            int xuatSac = studentList.Count(s => s.AverageScore >= 9 && s.AverageScore <= 10);
            int gioi = studentList.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            int kha = studentList.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            int duoi7 = studentList.Count(s => s.AverageScore < 7);
            Console.WriteLine("=== THONG KE XEP LOAI ===");
            Console.WriteLine($"Xuat sac: {xuatSac}");
            Console.WriteLine($"Gioi: {gioi}");
            Console.WriteLine($"Kha: {kha}");
            Console.WriteLine($"Duoi 7 diem (tam gop): {duoi7}");
        }
    }
}