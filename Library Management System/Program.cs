using Library_Management_System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Xoş gəlmisiniz ;)");
        Console.WriteLine("Xaiş edirik proqrama giriş etmək üçün aşağıda İstifadəçi adınızı və Şifrənizi daxil");
        Console.ForegroundColor = ConsoleColor.White;
        // Programın əsas obyekti yaradılır və Run metodu çağrılır.
        Program program = new Program();
        program.Run();
    }

    void Run()
    {
        try
        {
            // İstifadəçinin doğrulanması üçün AuthenticateUser metodu çağrılır.
            bool isUserAuthenticated = AuthenticateUser();
            int loginAttemps = 0;
            Library library = new Library();

            // İstifadəçinin doğrulanması üçün AuthenticateUser metodu çağrılır.
            while (!isUserAuthenticated)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\"Daxil etdiyiniz istifadəçi adı və ya şifrə yalnışdır!\"");
                loginAttemps++;
                Console.ForegroundColor = ConsoleColor.White;

                // 5 dəfə yanlış giriş etdikdə proqramın bağlanması.
                if (loginAttemps >= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Siz 5 dəfə yanlış istifadəçi adı və ya şifrə daxil etdiniz. Proqram bağlanır.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                isUserAuthenticated = AuthenticateUser();
            }

            // Proqramın menyu funksiyaları üçün sonsuz döngü yaradılır. 
            while (true)
            {
                // Menyunun göstərilməsi üçün DisplayMenu metodu çağrılır.
                DisplayMenu();
                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        // Kitabxanadakı elementlərin siyahısının göstərilməsi.
                        library.DisplayLibraryItems();
                        break;
                    case 2:
                        // Element əlavə etmə funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        AddLibraryItemWithExceptionHandling(library);
                        break;
                    case 3:
                        // Tələbəyə kitab vermə funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        LendItemToStudentWithExceptionHandling(library);
                        break;
                    case 4:
                        // Kitabxanada axtarış funksiyası çağrılır və xəta baş verərsə o çap edilir.
                        SearchLibraryWithExceptionHandling(library);
                        break;
                    case 5:
                        // Proqramın bağlanması.
                        Console.WriteLine("Proqram bağlanır. ");
                        return;
                    default:
                        // Yanlış seçim halında istifadəçiyə bildiriş göstərilir.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Yanlış seçim! Zəhmət olmasa düzgün əməliyyatı seçin.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            // Əgər proqramın işlənməsi zamanı bir xəta baş verərsə istifadəçiyə bildiriş göstərilir.
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
        }
        finally
        {
            // Bura əlavə təmizləmə və ya başqa tədbirlər əlavə edilə bilər.
            Thread.Sleep(5000);
            Console.Clear();
        }
    }

    public bool AuthenticateUser()
    {
        try
        {
            // İstifadəçi adı və şifrəni almaq üçün istifadəçiyə soruşulur.
            Console.WriteLine("İstifadəçi adı: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Şifrə: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string password = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            // Daxil edilmiş məlumatların Zeynalın məlumatları ilə uyğunluğunu yoxlamaq.
            if (username == "Zeynal" && password == "Zeynal123")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Giriş uğurla başa çatdı!");
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Giriş uğursuz oldu. Yenidən cəhd edin.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
        catch (Exception ex)
        {
            // Əgər xəta baş verərsə istifadəçiyə bildiriş göstərilir.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

    }

    public void AddLibraryItemWithExceptionHandling(Library library)
    {
        try
        {
            // Kitabxanaya yeni element əlavə etmə funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.AddLibraryItem();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void LendItemToStudentWithExceptionHandling(Library library)
    {
        try
        {
            // Tələbəyə kitab vermə funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.LendItemToStudent();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void SearchLibraryWithExceptionHandling(Library library)
    {
        
        try
        {
            // Kitabxanada axtarış funksiyası çağrılır və xəta baş verərsə o çap edilir.
            library.SearchLibrary();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Xəta baş verdi: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void DisplayMenu()
    {
        // Proqramın əsas menyu seçimlərinin göstərilməsi:
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n-----------------------------------");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1. Kitabxanadakı element siyahısı");
        Console.WriteLine("2. Element əlavə etmək");
        Console.WriteLine("3. Tələbəyə (kirayə) kitab vermək");
        Console.WriteLine("4. Kitabxanada axtarış etmək");
        Console.WriteLine("5. Proqramdan çıxmaq");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("-----------------------------------");
        Console.Write("Seçiminizi daxil edin: ");
        Console.ForegroundColor = ConsoleColor.White;
    }
}