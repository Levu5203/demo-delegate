using DemoOOP;

internal class Program
{
    //Khai bao Delegate
    public delegate void ShowMessage(String msg);

    //MultiDelegate
    public delegate void ShowMultiMessage(String msg);
    public delegate void Maths(int a, int b);

    private static void Main(string[] args)
    {
        // Demo Delegate basic
        ShowMessage showMessage = Display;
        showMessage("Hello, Delegate!");

        /*
        Tại sao không gọi thẳng hàm trực tiếp luôn mà phải thông qua delegate
        Bạn không thể gọi nhiều phương thức cùng lúc nếu gọi trực tiếp
        Multicast delegate sinh ra để làm điều đó bằng toán tử
        */
        ShowMessage showMultiMessage = DisplayA;
        showMultiMessage += DisplayB;
        showMultiMessage("Hello!");

        Maths operations = Add;
        operations += Subtract;
        operations(10, 5);


        //Multicast với Anonymous method
        ShowMessage showAnonymousMessage = delegate (string msg)
        {
            Console.WriteLine("Anonymous Method 1: " + msg);
        };
        // Thêm phương thức vào danh sách gọi của delegate có dùng lambda
        showAnonymousMessage += msg =>
        {
            Console.WriteLine("Anonymous Method 2: " + msg);
        };
        // Gọi delegate
        showMessage("Hello, Multicast Delegate!");


        //Demo với Employee
        EmployeeService service = new EmployeeService();

        // Thêm nhân viên
        service.create(new Employee { id = 1, name = "Alice", Position = "Developer", Salary = 6000 });
        service.create(new Employee { id = 2, name = "Bob", Position = "Manager", Salary = 8000 });

        // Lấy danh sách nhân viên
        Console.WriteLine("Danh sách nhân viên:");
        foreach (var emp in service.getAll())
        {
            Console.WriteLine($"{emp.id} - {emp.name} ({emp.Position}), Lương: {emp.Salary:C}");
        }

        //tính lương sau thuế
        decimal tax = service.CalculateTax(service.getById(1));
        Console.WriteLine($"Thuế của Alice: {tax:C}");


    }

    //Display
    public static void Display(string msg)
    {
        Console.WriteLine("Message: " + msg);
    }

    // DisplayA và DisplayB để demo Multicast delegate
    public static void DisplayA(string msg)
    {
        Console.WriteLine("A: " + msg);
    }

    public static void DisplayB(string msg)
    {
        Console.WriteLine("B: " + msg);
    }

    // Demo Multicast Delegate và Demo Lambda (x, y) => x + y
    public static void Add(int a, int b) => Console.WriteLine($"Addition: {a + b}");
    public static void Subtract(int a, int b) => Console.WriteLine($"Subtraction: {a - b}");
}