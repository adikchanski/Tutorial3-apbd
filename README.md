Project Description:
A C# console application. This system manages the lifecycle of university equipment rentals, including inventory tracking, user limits, and penalty calculations.
Design Decisions & Justification
1. Separation of Responsibilities(Cohesion)
To ensure the code remains maintainable and readable, the project is divided into specialized layers:
Models: Equipment, User, and Rental are pure domain objects. They hold data and state but do not interact with the console or handle high-level business flow.
RentalService: This is the core logic engine. It is responsible for checking availability, enforcing user rental limits, and updating the state of items.
ReportService: This layer is dedicated to output. By separating reporting from the rental logic, we ensure that changing the user interface doesn't require modifying the core business rules.
2. Loose Coupling through Inheritance
The system uses an abstract Equipment base class. This allows the RentalService to perform operations (like RentEquipment or ReturnEquipment) on any device be it a Laptop, Projector, or Camera without needing to know the specific technical details of that device.

How to run?
Open the project in an IDE
Run the application. The Program.cs file will execute a full Demonstration Scenario which includes:
- Adding equipment and users.
- Marking items as unavailable.
- Successful and blocked rental attempts.
- Penalty calculation for a simulated late return.
- A final summary report.

Git Branching & Merging Note
During the development of this project, I used several feature branches (user, domain-logic, and domain-enhancements) to organize my work. But unfortunately, somehow I guess I did a fast-forward merge and it doesn't show in the logs that different commits were made on different branches. Sorry...
