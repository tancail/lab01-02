using System;
using System.Globalization;
class Student
{
   private string studentID = "";
    private string fullName = "";
    private float averageScore;
    private string faculty = "";
    public string StudentID { get => studentID; set => studentID = value; }
    public string FullName { get => fullName; set => fullName = value; }
    public float AverageScore { get => averageScore; set => averageScore = value; }
    public string Faculty { get => faculty; set => faculty = value; }
    public Student()
    {
    }
    public Student(string studentID, string fullName, float averageScore, string faculty)
    {
        this.studentID = studentID;
        this.fullName = fullName;
        this.averageScore = averageScore;
        this.faculty = faculty;
    }
    public void Input()
    {
        Console.Write("Nhap MSSV: ");
        StudentID = (Console.ReadLine() ?? "").Trim();
        Console.Write("Nhap ho ten sinh vien: ");
        FullName = (Console.ReadLine() ?? "").Trim();
        float diem;
        while (true)
        {
            Console.Write("Nhap diem trung binh (0–10): ");
            string diemNhap = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
            if (float.TryParse(diemNhap, NumberStyles.Float,
                CultureInfo.InvariantCulture, out diem) && diem >= 0 && diem <= 10)
            {
                AverageScore = diem;
                break;
            }
            Console.WriteLine("Điem khong hop le. Vui long nhap lai.");
        }
        Console.Write("Nhap khoa: ");
        Faculty = (Console.ReadLine() ?? "").Trim();
    }
    public void Show()
    {
        Console.WriteLine(
            $"MSSV: {StudentID} | Ho ten: {FullName} | Khoa: {Faculty} | Điem TB: {AverageScore}");
    }
}