Test Coverage: 70%

# Vehicle Perfomance Monitoring Desktop Application

This project is for a perfomance monitoring application that tracks a group of ground vehicles where GPS, temperature, and humidity is monitored and tracked in real time.

## Getting Started
To get started on your own machine fork the project onto your own repository, then use the command git clone, followed by the url of the forked repository. This will get the project onto your own machine for development, testing, and usage purposes.

### Prerequisites
The tech/frameworks used to run this project are as follows:

[ASP.NET](https://dotnet.microsoft.com/apps/aspnet) An open source framework for building modern web apps and services with .NET

[SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr) A free and open-source software library for Microsoft ASP.NET that allows server code to send asynchronous notifications to client-side web applications.

[WPF](https://visualstudio.microsoft.com/vs/features/wpf/) a free and open source graphical subsystem for rendering user interfaced in Windows based applications.

[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) An Integrated Development environment which is recommended.

## Code Style

This project implements the Model-View-Controller (MVC) and Repository design pattern.

The project set up its database using the Object Relational Mapper (ORM) which allowed the database tables to be created and updated based on classes defined in the application through the use of migrations.

## Code Example

The following code is taken from the AlertUtility class.  This class is responsible for setting the AlertType received by the API and determining what AlertColour is returned.

```
 public Alert RetrieveTempAlert(Vehicle x)
        {
            Alert alert = CreateAlert(x);
            alert.AlertType = "Temperature";
            if (x.VehicleTemp > 25 || x.VehicleTemp < -60)
            {
                // (Temp) Alert is set to red
                alert.AlertColour = "Red";
                SaveAlert(alert);
            }
            else if ((x.VehicleTemp >= -60 && x.VehicleTemp <= -15)
                || (x.VehicleTemp >= 16 && x.VehicleTemp <= 25))
            {
                // (Temp) Alert is set to amber
                alert.AlertColour="Amber";
            }
            else
            {
                // (Temp) Alert is set to green
                alert.AlertColour = "Green";
            }
            return alert;
        }
```

## Installing
This application can be run from Visual Studio Code directly or alternatively it be hosted and deployed via the instruction in the following link https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/?view=aspnetcore-5.0



## Running Tests

### Mock Tests

C# Unit Tests with Mocks provide a simple method of minimising unwanted dependencies when writing unit tests.
```
 public VehicleControllerTesting()
        {
            //mock setup
            vehicleMock = new Mock<IVehicle>();
            vehiclesMock = new List<IVehicle> { vehicleMock.Object };
            addVehicleMock = new Mock<IAddVehicle>();
            updateVehicleMock = new Mock<IUpdateVehicle>();
            vehicle = new Vehicle();
            vehicles = new List<Vehicle>();

            //view models mock setup
            vehicleViewModelMock = new Mock<IVehicleViewModel>();
            vehiclesViewModelMock = new List<IVehicleViewModel>();

            //sample models
            addVehicle = new AddVehicle { Latitude = 10, Longitude = 10, VehicleHumidity = 10, VehicleTemp = 10 };
            updateVehicle = new UpdateVehicle { Latitude = 999, Longitude = 999, VehicleHumidity = 60, VehicleTemp = 80 };

            //controller setup
            _logger = new Mock<ILogger<VehicleController>>();
            repoMock = new Mock<IRepositoryWrapper>();
            alertMock = new Mock<IAlert>();
            var allVehicles = GetVehicles();
            var onevehicle = GetVehicle();
            vehicleController = new VehicleController(_logger.Object, repoMock.Object);

```
## Built With
* [VisualStudio2019](https://visualstudio.microsoft.com/downloads/) - .NET IDE

* [EntityFramework](https://docs.microsoft.com/en-us/ef/) - Object Relational Mapping Framework


## Versioning
Version 1.0

## Authors
* **Andrew Klein** -[andrewklein]()
* **Andrew Osborne** -[andrewosborne]()
* **Gabriela Yordanova** -[gabrielayordanova]()
* **Matthew Cameron** -[matthewcameron]()

## License

This project is licensed under the MIT license = see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Dara Oladapo for his time and guidance.
