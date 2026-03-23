using Tutorial3_apbd.model;
using Tutorial3_apbd.Services;
 
var rentalService = new RentalService();
var reportService = new ReportService(rentalService);
 
//1.Add equipment of different types
Console.WriteLine("=== Adding Equipment ===");
var laptop = new Laptop("Asus VivoBook", 16, "i7");
var projector = new Projector("Epson EB-X51", 3500, "1920x1080");
var camera = new Camera("Canon EOS M50", 24, true);
var damagedLaptop = new Laptop("Old Dell", 4, "i3");
 
rentalService.AddEquipment(laptop);
rentalService.AddEquipment(projector);
rentalService.AddEquipment(camera);
rentalService.AddEquipment(damagedLaptop);

rentalService.MarkUnavailable(damagedLaptop, "damaged screen");
 
reportService.PrintAllEquipment();
reportService.PrintAvailableEquipment();
 
//2. Add users of different types
Console.WriteLine("\n=== Adding Users ===");
var student = new Student(1, "Anna", "Nowak");
var employee = new Employee(2, "Jan", "Kowalski");
var student2 = new Student(3, "Piotr", "Wiśniewski");
 
rentalService.AddUser(student);
rentalService.AddUser(employee);
rentalService.AddUser(student2);
 
Console.WriteLine($"Added: {student}");
Console.WriteLine($"Added: {employee}");
Console.WriteLine($"Added: {student2}");
 
//3.Correct rental
Console.WriteLine("\n=== Correct Rental ===");
rentalService.RentEquipment(student, laptop, 7);
Console.WriteLine($"Rented '{laptop.Name}' to {student.FirstName} for 7 days.");
 
rentalService.RentEquipment(student, projector, 3);
Console.WriteLine($"Rented '{projector.Name}' to {student.FirstName} for 3 days.");
 
reportService.PrintUserActiveRentals(student);
 
//4a.Invalid: renting unavailable (damaged) equipment
Console.WriteLine("\n=== Attempt: Rent Unavailable Equipment ===");
try
{
    rentalService.RentEquipment(employee, damagedLaptop, 5);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Blocked: {e.Message}");
}
 
//4b.Invalid: student exceeds rental limit(max was 2)
Console.WriteLine("\n=== Attempt: Exceed Student Rental Limit ===");
try
{
    rentalService.RentEquipment(student, camera, 5); // student already has 2
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Blocked: {e.Message}");
}
 
//5.On-time return
Console.WriteLine("\n=== On-Time Return ===");
rentalService.ReturnEquipment(projector);
 
//6.Late return with penalty
//Simulate a late return by backdating the DueDate on an existing rental
Console.WriteLine("\n=== Late Return (simulated) ===");
rentalService.RentEquipment(employee, camera, 7);
 
//Manually backdate the due date to simulate a 3-day late return
var lateRental = rentalService.GetAllRentals()
    .First(r => r.Equipment == camera && !r.IsReturned);
lateRental.DueDate = DateTime.Now.AddDays(-3); //pretend it was due 3 days ago
 
rentalService.ReturnEquipment(camera); //should charge 3*10 = 30PLN
 
//7.Overdue rentals
//Make laptop overdue too
var laptopRental = rentalService.GetAllRentals()
    .First(r => r.Equipment == laptop && !r.IsReturned);
laptopRental.DueDate = DateTime.Now.AddDays(-1);
 
reportService.PrintOverdueRentals();
 
//8.Active rentals for a user
reportService.PrintUserActiveRentals(student);
 
//9. Final summary report
reportService.PrintSummaryReport();