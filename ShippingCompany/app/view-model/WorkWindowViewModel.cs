using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DynamicData;
using ShippingCompany.commands;
using ShippingCompany.data.crud;
using ShippingCompany.domain.entities;
using ShippingCompany.Domain.Entities;
using ShippingCompany.domain.enums;

namespace ShippingCompany.app.view_model;

public class WorkWindowViewModel: BaseViewModel
{
    // Коллекции всех таблиц из БД
    public ObservableCollection<User> Users { get; set; }
    public ObservableCollection<User> FilteredUsers { get; set; }
    public ObservableCollection<Town> Towns { get; set; }
    public ObservableCollection<Town> FilteredTowns { get; set; }
    public ObservableCollection<Street> Streets { get; set; }
    public ObservableCollection<Street> FilteredStreets { get; set; }
    public ObservableCollection<Bank> Banks { get; set; }
    public ObservableCollection<Bank> FilteredBanks { get; set; }
    public ObservableCollection<Port> Ports { get; set; }
    public ObservableCollection<Port> FilteredPorts { get; set; }
    public ObservableCollection<Ship> Ships { get; set; }
    public ObservableCollection<Ship> FilteredShips { get; set; }
    public ObservableCollection<TypeOfCargo> TypesOfCargo { get; set; }
    public ObservableCollection<TypeOfCargo> FilteredTypesOfCargo { get; set; }
    public ObservableCollection<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
    public ObservableCollection<UnitOfMeasurement> FilteredUnitsOfMeasurement { get; set; }
    public ObservableCollection<Voyage> Voyages { get; set; }
    public ObservableCollection<Voyage> FilteredVoyages { get; set; }
    

    public ICommand SettingsButton { get; }
    public ICommand UsersButton { get; }
    public ICommand TownsButton { get; }
    public ICommand StreetsButton { get; }
    public ICommand BanksButton { get; }
    public ICommand PortsButton { get; }
    public ICommand ShipsButton { get; }
    public ICommand TypesOfCargoButton { get; }
    public ICommand UnitOfMeasurementButton { get; }
    public ICommand VoyageButton { get; }
    public ICommand ClientCompaniesButton { get; }
    
    // Видимость всех окон меню
    private Visibility _usersListControlVisible = Visibility.Collapsed;
    private Visibility _homepageVisible = Visibility.Visible;
    private Visibility _settingsVisible = Visibility.Collapsed;
    private Visibility _townsListControlVisible = Visibility.Collapsed;
    private Visibility _streetsListControlVisible = Visibility.Collapsed;
    private Visibility _banksListControlVisible = Visibility.Collapsed;
    private Visibility _portsListControlVisible = Visibility.Collapsed;
    private Visibility _shipsListControlVisible = Visibility.Collapsed;
    private Visibility _typesOfCargoListControlVisible = Visibility.Collapsed; 
    private Visibility _unitOfMeasurementListControlVisible = Visibility.Collapsed;
    private Visibility _voyagesGridControlVisible = Visibility.Collapsed;
    private Visibility _clientCompaniesListControlVisible = Visibility.Collapsed;
    
    public Visibility UsersListControlVisible
    {
        get => _usersListControlVisible;
        set
        {
            _usersListControlVisible = value;
            OnPropertyChanged();
        }
    }
    public Visibility HomepageVisible
    {
        get => _homepageVisible;
        set
        {
            _homepageVisible = value;
            OnPropertyChanged();
        }
    }
    public Visibility SettingsVisible
    {
        get => _settingsVisible;
        set
        {
            _settingsVisible = value;
            OnPropertyChanged();
        }
    }
    public Visibility TownsListControlVisible
    {
        get => _townsListControlVisible;
        set
        {
            _townsListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility StreetsListControlVisible
    {
        get => _streetsListControlVisible;
        set
        {
            _streetsListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility BanksListControlVisible
    {
        get => _banksListControlVisible;
        set
        {
            _banksListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility PortsListControlVisible
    {
        get => _portsListControlVisible;
        set
        {
            _portsListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility ShipsListControlVisible
    {
        get => _shipsListControlVisible;
        set
        {
            _shipsListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility TypesOfCargoListControlVisible
    {
        get => _typesOfCargoListControlVisible;
        set
        {
            _typesOfCargoListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility UnitOfMeasurementListControlVisible
    {
        get => _unitOfMeasurementListControlVisible;
        set
        {
            _unitOfMeasurementListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility VoyagesGridControlVisible
    {
        get => _voyagesGridControlVisible;
        set
        {
            _voyagesGridControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    public Visibility ClientCompaniesListControlVisible
    {
        get => _clientCompaniesListControlVisible;
        set
        {
            _clientCompaniesListControlVisible = value;
            OnPropertyChanged();
        }
    }
    
    // Crud для каждой таблицы из БД
    private readonly UserCrud _userCrud = new UserCrud();
    private readonly TownCrud _townCrud = new TownCrud();
    private readonly StreetCrud _streetCrud = new StreetCrud();
    private readonly BankCrud _bankCrud = new BankCrud();
    private readonly PortCrud _portCrud = new PortCrud();
    private readonly ShipCrud _shipCrud = new ShipCrud();
    private readonly TypeOfCargoCrud _typeOfCargoCrud = new TypeOfCargoCrud();
    private readonly UnitOfMeasurementCrud _unitOfMeasurementCrud = new UnitOfMeasurementCrud();
    private readonly VoyageCrud _voyageCrud = new VoyageCrud();
    private readonly VoyagePortCrud _voyagePortCrud = new VoyagePortCrud();
    private readonly ShipmentCrud _shipmentCrud = new ShipmentCrud();
    private readonly ClientCompanyCrud _clientCompanyCrud = new ClientCompanyCrud();
    
    // Атрибуты UsersListControl
    public ICommand DeleteUserButton { get; }
    public ICommand CreateUserButton { get; }
    public ICommand SaveChangesUserButton { get; }
    private int _userSelectedTabIndex;
    public bool IsUserSelected => SelectedUser != null;
    private User _selectedUser;
    private string _login;
    private string _password;
    private string _confirmPassword;
    private string _searchLogin;
    public int UserSelectedTabIndex
    {
        get => _userSelectedTabIndex;
        set
        {
            if (_userSelectedTabIndex != value)
            {
                _userSelectedTabIndex = value;
                OnPropertyChanged();
                
                if (_userSelectedTabIndex == 3) 
                {
                    SelectedUser = null;
                }
            }
        }
    }
    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            Login = _selectedUser?.Login;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsUserSelected));
        }
    }
    public string Login
    {
        get => _login;
        set
        {
            if (_login != value)
            {
                _login = value;
                OnPropertyChanged();
            }
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
            }
        }
    }
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            if (_confirmPassword != value)
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchLogin
    {
        get => _searchLogin;
        set
        {
            if (_searchLogin != value)
            {
                _searchLogin = value;
                OnPropertyChanged();
                UserPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты TownsListControl
    public ICommand DeleteTownButton { get; }
    public ICommand CreateTownButton { get; }
    public ICommand SaveChangesTownButton { get; }
    private int _townSelectedTabIndex;
    public bool IsTownSelected => SelectedTown != null;
    private Town _selectedTown;
    private string _townName;
    private string _searchTownName;
    public int TownSelectedTabIndex
    {
        get => _townSelectedTabIndex;
        set
        {
            if (_townSelectedTabIndex != value)
            {
                _townSelectedTabIndex = value;
                OnPropertyChanged();
            }
        }
    }
    public Town SelectedTown
    {
        get => _selectedTown;
        set
        {
            _selectedTown = value;
            TownName = _selectedTown?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsTownSelected));
        }
    }
    public string TownName
    {
        get => _townName;
        set
        {
            if (_townName != value)
            {
                _townName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchTownName
    {
        get => _searchTownName;
        set
        {
            if (_searchTownName != value)
            {
                _searchTownName = value;
                OnPropertyChanged();
                TownPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты StreetsListControl
    public ICommand DeleteStreetButton { get; }
    public ICommand CreateStreetButton { get; }
    public ICommand SaveChangesStreetButton { get; }
    private int _streetSelectedTabIndex;
    public bool IsStreetSelected => SelectedStreet != null;
    private Street _selectedStreet;
    private string _streetName;
    private string _searchStreetName;
    public int StreetSelectedTabIndex
    {
        get => _streetSelectedTabIndex;
        set
        {
            if (_streetSelectedTabIndex != value)
            {
                _streetSelectedTabIndex = value;
                OnPropertyChanged();
                if (_streetSelectedTabIndex == 3) 
                {
                    SelectedStreet = null;
                }
            }
        }
    }
    public Street SelectedStreet
    {
        get => _selectedStreet;
        set
        {
            _selectedStreet = value;
            StreetName = _selectedStreet?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsStreetSelected));
        }
    }
    public string StreetName
    {
        get => _streetName;
        set
        {
            if (_streetName != value)
            {
                _streetName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchStreetName
    {
        get => _searchStreetName;
        set
        {
            if (_searchStreetName != value)
            {
                _searchStreetName = value;
                OnPropertyChanged();
                StreetPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты BanksListControl
    public ICommand DeleteBankButton { get; }
    public ICommand CreateBankButton { get; }
    public ICommand SaveChangesBankButton { get; }
    private int _bankSelectedTabIndex;
    public bool IsBankSelected => SelectedBank != null;
    private Bank _selectedBank;
    private string _bankName;
    private string _searchBankName;
    public int BankSelectedTabIndex
    {
        get => _bankSelectedTabIndex;
        set
        {
            if (_bankSelectedTabIndex != value)
            {
                _bankSelectedTabIndex = value;
                OnPropertyChanged();
                if (_bankSelectedTabIndex == 3) 
                {
                    SelectedBank = null;
                }
            }
        }
    }
    public Bank SelectedBank
    {
        get => _selectedBank;
        set
        {
            _selectedBank = value;
            BankName = _selectedBank?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsBankSelected));
        }
    }
    public string BankName
    {
        get => _bankName;
        set
        {
            if (_bankName != value)
            {
                _bankName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchBankName
    {
        get => _searchBankName;
        set
        {
            if (_searchBankName != value)
            {
                _searchBankName = value;
                OnPropertyChanged();
                BankPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты PortsListControl
    public ICommand DeletePortButton { get; }
    public ICommand CreatePortButton { get; }
    public ICommand SaveChangesPortButton { get; }
    private int _portSelectedTabIndex;
    public bool IsPortSelected => SelectedPort != null;
    private Port _selectedPort;
    private string _portName;
    private string _searchPortName;
    public int PortSelectedTabIndex
    {
        get => _portSelectedTabIndex;
        set
        {
            if (_portSelectedTabIndex != value)
            {
                _portSelectedTabIndex = value;
                OnPropertyChanged();
                if (_portSelectedTabIndex == 3) 
                {
                    SelectedPort = null;
                }
            }
        }
    }
    public Port SelectedPort
    {
        get => _selectedPort;
        set
        {
            _selectedPort = value;
            PortName = _selectedPort?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsPortSelected));
        }
    }
    public string PortName
    {
        get => _portName;
        set
        {
            if (_portName != value)
            {
                _portName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchPortName
    {
        get => _searchPortName;
        set
        {
            if (_searchPortName != value)
            {
                _searchPortName = value;
                OnPropertyChanged();
                PortPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты TypesOfCargoListControl
    public ICommand DeleteTypeOfCargoButton { get; }
    public ICommand CreateTypeOfCargoButton { get; }
    public ICommand SaveChangesTypeOfCargoButton { get; }
    private int _typeOfCargoSelectedTabIndex;
    public bool IsTypeOfCargoSelected => SelectedTypeOfCargo != null;
    private TypeOfCargo _selectedTypeOfCargo;
    private string _typeOfCargoName;
    private string _searchTypeOfCargoName;
    public int TypeOfCargoSelectedTabIndex
    {
        get => _typeOfCargoSelectedTabIndex;
        set
        {
            if (_typeOfCargoSelectedTabIndex != value)
            {
                _typeOfCargoSelectedTabIndex = value;
                OnPropertyChanged();
                if (_typeOfCargoSelectedTabIndex == 3) 
                {
                    SelectedTypeOfCargo = null;
                }
            }
        }
    }
    public TypeOfCargo SelectedTypeOfCargo
    {
        get => _selectedTypeOfCargo;
        set
        {
            _selectedTypeOfCargo = value;
            TypeOfCargoName = _selectedTypeOfCargo?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsTypeOfCargoSelected));
        }
    }
    public string TypeOfCargoName
    {
        get => _typeOfCargoName;
        set
        {
            if (_typeOfCargoName != value)
            {
                _typeOfCargoName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchTypeOfCargoName
    {
        get => _searchTypeOfCargoName;
        set
        {
            if (_searchTypeOfCargoName != value)
            {
                _searchTypeOfCargoName = value;
                OnPropertyChanged();
                TypeOfCargoPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты ShipsListControl
    public ICommand DeleteShipButton { get; }
    public ICommand CreateShipButton { get; }
    public ICommand SaveChangesShipButton { get; }
    public ICommand SelectPhotoForShipButton { get; }
    public ICommand ToggleTypeOfCargoForShipButton { get; }
    public IEnumerable<ShipTypes> ShipTypes => Enum.GetValues(typeof(ShipTypes)).Cast<ShipTypes>();
    private int _shipSelectedTabIndex;
    public bool IsShipSelected => SelectedShip != null;
    private Ship _selectedShip;
    private Ship _editingShip;
    private Ship _addingShip;
    private Port _shipHomePort;
    private string _searchShipName;

    private List<TypeOfCargo> _selectedTypesOfCargoForShip;
    public List<TypeOfCargo> SelectedTypesOfCargoForShip
    {
        get => _selectedTypesOfCargoForShip;
        set
        {
            _selectedTypesOfCargoForShip = value;
            OnPropertyChanged();
        }
    }

    public int ShipSelectedTabIndex
    {
        get => _shipSelectedTabIndex;
        set
        {
            if (_shipSelectedTabIndex != value)
            {
                _shipSelectedTabIndex = value;
                OnPropertyChanged();
                if (_shipSelectedTabIndex == 1 || _shipSelectedTabIndex == 2)
                {
                    if (_shipSelectedTabIndex == 2) EditingShip = SelectedShip;
                    if (SelectedShip.PortId.HasValue)
                    {
                        ShipHomePort = _portCrud.ReadById(SelectedShip.PortId.Value);
                    }
                    else
                    {
                        ShipHomePort = null; // Или присвойте значение по умолчанию, если необходимо
                    }
                }
                if (_shipSelectedTabIndex == 3)
                {
                    AddingShip = new Ship();
                    SelectedShip = null;
                }
            }
        }
    }

    public Ship SelectedShip
    {
        get => _selectedShip;
        set
        {
            _selectedShip = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsShipSelected));
        }
    }

    public Ship EditingShip
    {
        get => _editingShip;
        set
        {
            _editingShip = value;
            OnPropertyChanged();
        }
    }

    public Ship AddingShip
    {
        get => _addingShip;
        set
        {
            if (_addingShip != value)
            {
                _addingShip = value;
                OnPropertyChanged();
            }
        }
    }
    
    public Port ShipHomePort
    {
        get => _shipHomePort;
        set
        {
            if (_shipHomePort != value)
            {
                _shipHomePort = value;
                OnPropertyChanged();
            }
        }
    }

    public string SearchShipName
    {
        get => _searchShipName;
        set
        {
            if (_searchShipName != value)
            {
                _searchShipName = value;
                OnPropertyChanged();
                ShipPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты UnitOfMeasurementListControl
    public ICommand DeleteUnitOfMeasurementButton { get; }
    public ICommand CreateUnitOfMeasurementButton { get; }
    public ICommand SaveChangesUnitOfMeasurementButton { get; }
    private int _unitOfMeasurementSelectedTabIndex;
    public bool IsUnitOfMeasurementSelected => SelectedUnitOfMeasurement != null;
    private UnitOfMeasurement _selectedUnitOfMeasurement;
    private string _unitOfMeasurementName;
    private string _searchUnitOfMeasurementName;
    public int UnitOfMeasurementSelectedTabIndex
    {
        get => _unitOfMeasurementSelectedTabIndex;
        set
        {
            if (_unitOfMeasurementSelectedTabIndex != value)
            {
                _unitOfMeasurementSelectedTabIndex = value;
                OnPropertyChanged();
                if (_unitOfMeasurementSelectedTabIndex == 3) 
                {
                    SelectedUnitOfMeasurement = null;
                }
            }
        }
    }
    public UnitOfMeasurement SelectedUnitOfMeasurement
    {
        get => _selectedUnitOfMeasurement;
        set
        {
            _selectedUnitOfMeasurement = value;
            UnitOfMeasurementName = _selectedUnitOfMeasurement?.Name;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsUnitOfMeasurementSelected));
        }
    }
    public string UnitOfMeasurementName
    {
        get => _unitOfMeasurementName;
        set
        {
            if (_unitOfMeasurementName != value)
            {
                _unitOfMeasurementName = value;
                OnPropertyChanged();
            }
        }
    }
    public string SearchUnitOfMeasurementName
    {
        get => _searchUnitOfMeasurementName;
        set
        {
            if (_searchUnitOfMeasurementName != value)
            {
                _searchUnitOfMeasurementName = value;
                OnPropertyChanged();
                UnitOfMeasurementPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    
    // Атрибуты VoyageGridControl
    private ObservableCollection<Shipment> _shipmentForVoyage;
    public ObservableCollection<Shipment> ShipmentForVoyage
    {
        get => _shipmentForVoyage;
        set
        {
            _shipmentForVoyage = value;
            OnPropertyChanged(nameof(ShipmentForVoyage)); // Уведомляем об изменении свойства
        }
    }
    public ICommand DeleteVoyageButton { get; }
    public ICommand CreateVoyageButton { get; }
    public ICommand SaveChangesVoyageButton { get; }
    public ICommand SaveChangesInGridVoyageButton { get; }
    public ICommand AddShipmentForVoyageButton { get; }
    public ICommand AddPortInVoyageButton { get; }
    private int _voyageSelectedTabIndex;
    public bool IsVoyageSelected => SelectedVoyage != null;
    private long _addShipmentIdForVoyage;
    private Port _selectedNewPortInVoyage;
    private Voyage _selectedVoyage;
    private Voyage _editingVoyage;
    private Voyage _addingVoyage;
    private string _searchVoyageId;

    public Port SelectedNewPortInVoyage
    {
        get => _selectedNewPortInVoyage;
        set
        {
            if (_selectedNewPortInVoyage != value)
            {
                _selectedNewPortInVoyage = value;
                OnPropertyChanged();
            }
        }
    }
    public long AddShipmentIdForVoyage
    {
        get => _addShipmentIdForVoyage;
        set
        {
            if (_addShipmentIdForVoyage != value)
            {
                _addShipmentIdForVoyage = value;
                OnPropertyChanged(nameof(AddShipmentIdForVoyage));
            }
        }
    }
    
    public int VoyageSelectedTabIndex
    {
        get => _voyageSelectedTabIndex;
        set
        {
            if (_voyageSelectedTabIndex != value)
            {
                _voyageSelectedTabIndex = value;
                OnPropertyChanged();
                if (_voyageSelectedTabIndex == 1 || _voyageSelectedTabIndex == 2)
                {
                    List<Shipment> shipmentsForVoyageList = _shipmentCrud.ReadByVoyageId(SelectedVoyage.Id);
                    ShipmentForVoyage = new ObservableCollection<Shipment>(shipmentsForVoyageList);
                    if (_voyageSelectedTabIndex == 2)
                    {
                        EditingVoyage = SelectedVoyage;
                        Console.WriteLine($"Voyage.Id {EditingVoyage.Id}");
                        Console.WriteLine($"VoyageShipName: {EditingVoyage.Ship.Name}");
                        foreach (VoyagePort voyagePort in EditingVoyage.VoyagePorts)
                        {
                            Console.WriteLine($"Port: {voyagePort.Port.Name}");
                        }
                        
                    }
                }
                if (_voyageSelectedTabIndex == 3)
                {
                    AddingShip = new Ship();
                    SelectedShip = null;
                }
            }
        }
    }

    public Voyage SelectedVoyage
    {
        get => _selectedVoyage;
        set
        {
            _selectedVoyage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsVoyageSelected));
        }
    }

    public Voyage EditingVoyage
    {
        get => _editingVoyage;
        set
        {
            _editingVoyage = value;
            OnPropertyChanged();
        }
    }

    public Voyage AddingVoyage
    {
        get => _addingVoyage;
        set
        {
            if (_addingVoyage != value)
            {
                _addingVoyage = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string SearchVoyageId
    {
        get => _searchVoyageId;
        set
        {
            if (_searchVoyageId != value)
            {
                _searchVoyageId = value;
                OnPropertyChanged();
                VoyageIdPerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    public WorkWindowViewModel(User currentUser)
    {
        SettingsButton = new RelayCommand(SettingsCommand);
        TownsButton = new RelayCommand(TownsCommand);
        UsersButton = new RelayCommand(UsersCommand);
        StreetsButton = new RelayCommand(StreetsCommand);
        BanksButton = new RelayCommand(BanksCommand);
        PortsButton = new RelayCommand(PortsCommand);
        ShipsButton = new RelayCommand(ShipsCommand);
        TypesOfCargoButton = new RelayCommand(TypesOfCargoCommand);
        UnitOfMeasurementButton = new RelayCommand(UnitOfMeasurementCommand);
        VoyageButton = new RelayCommand(VoyagesCommand);
        
        // Для UsersListControl
        List<User> userList =  _userCrud.ReadAll();
        this.Users = new ObservableCollection<User>(userList); // Преобразуем List в ObservableCollection
        FilteredUsers = new ObservableCollection<User>(Users);
        DeleteUserButton = new RelayCommand(DeleteUserCommand);
        CreateUserButton = new RelayCommand(CreateUserCommand);
        SaveChangesUserButton = new RelayCommand(SaveChangesUserCommand);
        
        // Для TownsListControl
        List<Town> townsList = _townCrud.ReadAll();
        this.Towns = new ObservableCollection<Town>(townsList);
        FilteredTowns = new ObservableCollection<Town>(Towns);
        DeleteTownButton = new RelayCommand(DeleteTownCommand);
        CreateTownButton = new RelayCommand(CreateTownCommand);
        SaveChangesTownButton = new RelayCommand(SaveChangesTownCommand);
        
        // Для StreetsListControl
        List<Street> streetsList = _streetCrud.ReadAll();
        this.Streets = new ObservableCollection<Street>(streetsList);
        FilteredStreets = new ObservableCollection<Street>(Streets);
        DeleteStreetButton = new RelayCommand(DeleteStreetCommand);
        CreateStreetButton = new RelayCommand(CreateStreetCommand);
        SaveChangesStreetButton = new RelayCommand(SaveChangesStreetCommand);
        
        // Для BanksListControl
        List<Bank> banksList = _bankCrud.ReadAll();
        this.Banks = new ObservableCollection<Bank>(banksList);
        FilteredBanks = new ObservableCollection<Bank>(Banks);
        DeleteBankButton = new RelayCommand(DeleteBankCommand);
        CreateBankButton = new RelayCommand(CreateBankCommand);
        SaveChangesBankButton = new RelayCommand(SaveChangesBankCommand);
        
        // Для PortsListControl
        List<Port> portsList = _portCrud.ReadAll();
        this.Ports = new ObservableCollection<Port>(portsList);
        FilteredPorts = new ObservableCollection<Port>(Ports);
        DeletePortButton = new RelayCommand(DeletePortCommand);
        CreatePortButton = new RelayCommand(CreatePortCommand);
        SaveChangesPortButton = new RelayCommand(SaveChangesPortCommand);
        
        // Для TypesOfCargoListControl
        List<TypeOfCargo> typesOfCargoList = _typeOfCargoCrud.ReadAll();
        this.TypesOfCargo = new ObservableCollection<TypeOfCargo>(typesOfCargoList);
        FilteredTypesOfCargo = new ObservableCollection<TypeOfCargo>(TypesOfCargo);
        DeleteTypeOfCargoButton = new RelayCommand(DeleteTypeOfCargoCommand);
        CreateTypeOfCargoButton = new RelayCommand(CreateTypeOfCargoCommand);
        SaveChangesTypeOfCargoButton = new RelayCommand(SaveChangesTypeOfCargoCommand);
        
        // Для ShipsListControl
        List<Ship> shipsList = _shipCrud.ReadAll();
        this.Ships = new ObservableCollection<Ship>(shipsList);
        FilteredShips = new ObservableCollection<Ship>(Ships);
        DeleteShipButton = new RelayCommand(DeleteShipCommand);
        CreateShipButton = new RelayCommand(CreateShipCommand);
        SaveChangesShipButton = new RelayCommand(SaveChangesShipCommand);
        SelectPhotoForShipButton = new RelayCommand(SelectPhotoForShipCommand);
        ToggleTypeOfCargoForShipButton = new RelayCommand(ToggleTypeOfCargoForShipCommand);
        
        
        // _shipmentCrud.Create(new Shipment(1, 1,
        //     null, null, null,
        //     "12345", "12345", null, null));
        // Voyage editVoyage = _voyageCrud.ReadById(1);
        // editVoyage.DepartureDate = new DateTime(2024, 12, 26, 0, 0, 0, DateTimeKind.Utc);
        // editVoyage.ArrivalDate = new DateTime(2024, 12, 30, 0, 0, 0, DateTimeKind.Utc);
        // _voyageCrud.Update(editVoyage);
        
        // Для VoyagesGridControl
        List<Voyage> voyagesList = _voyageCrud.ReadAll();
        this.Voyages = new ObservableCollection<Voyage>(voyagesList);
        FilteredVoyages = new ObservableCollection<Voyage>(Voyages);
        DeleteVoyageButton = new RelayCommand(DeleteShipCommand);
        CreateVoyageButton = new RelayCommand(CreateShipCommand);
        SaveChangesVoyageButton = new RelayCommand(SaveChangesShipCommand);
        SaveChangesInGridVoyageButton = new RelayCommand(SaveChangesInGridVoyageCommand);
        AddShipmentForVoyageButton = new RelayCommand(AddShipmentForVoyageCommand);
        AddPortInVoyageButton = new RelayCommand(AddPortInVoyageCommand);
        
        // Для UnitOfMeasurementListControl
        List<UnitOfMeasurement> unitsOfMeasurementList = _unitOfMeasurementCrud.ReadAll();
        this.UnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(unitsOfMeasurementList);
        FilteredUnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(UnitsOfMeasurement);
        DeleteUnitOfMeasurementButton = new RelayCommand(DeleteUnitOfMeasurementCommand);
        CreateUnitOfMeasurementButton = new RelayCommand(CreateUnitOfMeasurementCommand);
        SaveChangesUnitOfMeasurementButton = new RelayCommand(SaveChangesUnitOfMeasurementCommand);
    }

    private void SettingsCommand(object parameter)
    {
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        HomepageVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Visible;
        
    }

    private void UsersCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Visible;
    }
    
    private void TownsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Visible;
    }
    
    private void StreetsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Visible;
    }

    private void BanksCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Visible;
    }
    
    private void PortsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Visible;
    }
    
    private void ShipsCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Visible;
    }
    
    private void TypesOfCargoCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Visible;
    }
    
    private void UnitOfMeasurementCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Visible;
    }
    
    private void VoyagesCommand(object parameter)
    {
        HomepageVisible = Visibility.Collapsed;
        SettingsVisible = Visibility.Collapsed;
        UsersListControlVisible = Visibility.Collapsed;
        TownsListControlVisible = Visibility.Collapsed;
        StreetsListControlVisible = Visibility.Collapsed;
        BanksListControlVisible = Visibility.Collapsed;
        PortsListControlVisible = Visibility.Collapsed;
        ShipsListControlVisible = Visibility.Collapsed;
        TypesOfCargoListControlVisible = Visibility.Collapsed;
        UnitOfMeasurementListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Visible;
    }
    
    private void DeleteUserCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить пользователя {SelectedUser.Login}?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _userCrud.Delete(SelectedUser);
            FilteredUsers.Remove(SelectedUser);
            MessageBox.Show("Пользователь удалён");
            UserSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            UserSelectedTabIndex = 0;
        }
    }
    
    private void CreateUserCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(Login) && 
            !string.IsNullOrWhiteSpace(Password) &&
            !string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            if (_userCrud.ReadByLogin(Login) == null)
            {
                if (Password == ConfirmPassword)
                {
                    SelectedUser = new User(Login, Password);
                    _userCrud.Create(SelectedUser);
                    MessageBox.Show("Пользователь успешно создан");
                    FilteredUsers.Add(SelectedUser);
                    UserSelectedTabIndex = 0;
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Этот логин уже занят");
            }
        }
        else
        {
            MessageBox.Show("Логин не может быть пустым!");
        }
    }
    
    private void SaveChangesUserCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(Login))
        {
            var existingUser = _userCrud.ReadByLogin(Login);
            if (existingUser != null && existingUser.Id != SelectedUser.Id)
            {
                // Пользователь с таким логином уже существует (и это не тот же самый пользователь)
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите поменять логин пользователя?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Действие при выборе "Да"
                    SelectedUser.Login = Login;
                    _userCrud.Update(SelectedUser);
                    FilteredUsers.Replace(SelectedUser, SelectedUser);
                    MessageBox.Show("Пользователь успешно обновлён");
                    // Обновляем список пользователей
                    List<User> userList =  _userCrud.ReadAll();
                    this.FilteredUsers = new ObservableCollection<User>(userList);
                    
                    // Уведомляем об изменении свойства Users
                    OnPropertyChanged(nameof(FilteredUsers));
                    UserSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Логин пустой");
        }
    }
    
    private void UserPerformSearch()
    {
        // Фильтрация по логину
        var filtered = Users
            .Where(u => string.IsNullOrEmpty(SearchLogin) || 
                        u.Login.Contains(SearchLogin, System.StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Обновляем FilteredUsers без изменения привязанного свойства
        FilteredUsers.Clear();
        foreach (var user in filtered)
        {
            FilteredUsers.Add(user);
        }
    }
    
    
    
    private void DeleteTownCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить город?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _townCrud.Delete(SelectedTown);
            FilteredTowns.Remove(SelectedTown);
            MessageBox.Show("Город удалён");
            TownSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            TownSelectedTabIndex = 0;
        }
    }
    
    private void CreateTownCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(TownName))
        {
            if (_townCrud.ReadByName(TownName) == null)
            {
                SelectedTown = new Town(TownName);
                _townCrud.Create(SelectedTown);
                MessageBox.Show("Город успешно добавлен");
                FilteredTowns.Add(SelectedTown);
                TownSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesTownCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(TownName))
        {
            var existingTown = _townCrud.ReadByName(TownName);
            if (existingTown != null && existingTown.Id != SelectedTown.Id)
            {
                // Город с таким названием уже существует (и это не тот же самый пользователь)
                MessageBox.Show("Город с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать город?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Действие при выборе "Да"
                    SelectedTown.Name = TownName;
                    _townCrud.Update(SelectedTown);
                    FilteredTowns.Replace(SelectedTown, SelectedTown);
                    MessageBox.Show("Город успешно обновлён");
                    // Обновляем список городов
                    List<Town> townList =  _townCrud.ReadAll();
                    this.FilteredTowns = new ObservableCollection<Town>(townList);
                    // Уведомляем об изменении свойства Towns
                    OnPropertyChanged(nameof(FilteredTowns));
                    TownSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void TownPerformSearch()
    {
        // Фильтрация по названию города
        var filtered = Towns
            .Where(u => string.IsNullOrEmpty(SearchTownName) ||
                        u.Name.Contains(SearchTownName, System.StringComparison.OrdinalIgnoreCase))
            .ToList();
        // Обновляем FilteredTowns без изменения привязанного свойства
        FilteredTowns.Clear();
        foreach (var town in filtered)
        {
            FilteredTowns.Add(town);
        }
    }
    
    private void DeleteStreetCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить улицу?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _streetCrud.Delete(SelectedStreet);
            FilteredStreets.Remove(SelectedStreet);
            MessageBox.Show("Улица удалена");
            StreetSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            StreetSelectedTabIndex = 0;
        }
    }
    
    private void CreateStreetCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(StreetName))
        {
            if (_streetCrud.ReadByName(StreetName) == null)
            {
                SelectedStreet = new Street(StreetName);
                _streetCrud.Create(SelectedStreet);
                MessageBox.Show("Улица успешно добавлена");
                FilteredStreets.Add(SelectedStreet);
                StreetSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesStreetCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(StreetName))
        {
            var existingStreet = _streetCrud.ReadByName(StreetName);
            if (existingStreet != null && existingStreet.Id != SelectedStreet.Id)
            {
                MessageBox.Show("Улица с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать город?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SelectedStreet.Name = StreetName;
                    _streetCrud.Update(SelectedStreet);
                    FilteredStreets.Replace(SelectedStreet, SelectedStreet);
                    MessageBox.Show("Улица успешно обновлена");
                    // Обновляем список улиц
                    List<Street> streetList =  _streetCrud.ReadAll();
                    this.FilteredStreets = new ObservableCollection<Street>(streetList);
                    // Уведомляем об изменении свойства Streets
                    OnPropertyChanged(nameof(FilteredStreets));
                    StreetSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void StreetPerformSearch()
    {
        // Проверяем, есть ли исходные данные для Streets
        if (Streets == null)
            return;

        // Фильтрация по названию улицы
        var filtered = Streets
            .Where(u => string.IsNullOrEmpty(SearchStreetName) ||
                        u.Name.Contains(SearchStreetName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredStreets = new ObservableCollection<Street>(filtered);

        // Уведомляем об изменении свойства FilteredStreets
        OnPropertyChanged(nameof(FilteredStreets));
    }
    
    private void DeleteBankCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить банк?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _bankCrud.Delete(SelectedBank);
            FilteredBanks.Remove(SelectedBank);
            MessageBox.Show("Банк удалён");
            BankSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            BankSelectedTabIndex = 0;
        }
    }
    
    private void CreateBankCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(BankName))
        {
            if (_bankCrud.ReadByName(BankName) == null)
            {
                SelectedBank = new Bank(BankName);
                _bankCrud.Create(SelectedBank);
                MessageBox.Show("Банк успешно добавлен");
                FilteredBanks.Add(SelectedBank);
                BankSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesBankCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(BankName))
        {
            var existingBank = _bankCrud.ReadByName(BankName);
            if (existingBank != null && existingBank.Id != SelectedBank.Id)
            {
                MessageBox.Show("Банк с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать банк?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SelectedBank.Name = BankName;
                    _bankCrud.Update(SelectedBank);
                    FilteredBanks.Replace(SelectedBank, SelectedBank);
                    MessageBox.Show("Банк успешно обновлён");
                    List<Bank> bankList =  _bankCrud.ReadAll();
                    this.FilteredBanks = new ObservableCollection<Bank>(bankList);
                    OnPropertyChanged(nameof(FilteredBanks));
                    BankSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void BankPerformSearch()
    {
        if (Banks == null)
            return;

        // Фильтрация по названию улицы
        var filtered = Banks
            .Where(u => string.IsNullOrEmpty(SearchBankName) ||
                        u.Name.Contains(SearchBankName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredBanks = new ObservableCollection<Bank>(filtered);

        // Уведомляем об изменении свойства FilteredStreets
        OnPropertyChanged(nameof(FilteredBanks));
    }
    
    private void DeletePortCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить порт?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _portCrud.Delete(SelectedPort);
            FilteredPorts.Remove(SelectedPort);
            MessageBox.Show("Порт удалён");
            PortSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            PortSelectedTabIndex = 0;
        }
    }
    
    private void CreatePortCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(PortName))
        {
            if (_portCrud.ReadByName(PortName) == null)
            {
                SelectedPort = new Port(PortName);
                _portCrud.Create(SelectedPort);
                MessageBox.Show("Порт успешно добавлен");
                FilteredPorts.Add(SelectedPort);
                PortSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesPortCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(PortName))
        {
            var existingPort = _portCrud.ReadByName(PortName);
            if (existingPort != null && existingPort.Id != SelectedPort.Id)
            {
                MessageBox.Show("Порт с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать порт?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SelectedPort.Name = PortName;
                    _portCrud.Update(SelectedPort);
                    FilteredPorts.Replace(SelectedPort, SelectedPort);
                    MessageBox.Show("Порт успешно обновлён");
                    List<Port> portList =  _portCrud.ReadAll();
                    this.FilteredPorts = new ObservableCollection<Port>(portList);
                    OnPropertyChanged(nameof(FilteredPorts));
                    PortSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void PortPerformSearch()
    {
        if (Ports == null)
            return;
        var filtered = Ports
            .Where(u => string.IsNullOrEmpty(SearchPortName) ||
                        u.Name.Contains(SearchPortName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredPorts = new ObservableCollection<Port>(filtered);

        // Уведомляем об изменении свойства FilteredStreets
        OnPropertyChanged(nameof(FilteredPorts));
    }
    
    private void DeleteShipCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить судно?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _shipCrud.Delete(SelectedShip);
            FilteredShips.Remove(SelectedShip);
            MessageBox.Show("Судно удалено");
            ShipSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            ShipSelectedTabIndex = 0;
        }
    }
    private void SelectPhotoForShipCommand(object parameter)
    {
        try
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Выберите фотографию судна",
                Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                if (_shipSelectedTabIndex == 2)
                {
                    
                    EditingShip.PhotoPath = openFileDialog.FileName;
                }

                if (_shipSelectedTabIndex == 3)
                {
                    if (AddingShip == null)
                    {
                        MessageBox.Show("Объект AddingShip не инициализирован.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    AddingShip.PhotoPath = openFileDialog.FileName;
                    OnPropertyChanged(nameof(AddingShip.PhotoPath));
                    Console.WriteLine(AddingShip.PhotoPath);
                }
                MessageBox.Show("Фотография успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    private void CreateShipCommand(object parameter)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(AddingShip.Name) &&
                !string.IsNullOrWhiteSpace(AddingShip.RegistrationNumber) &&
                !string.IsNullOrWhiteSpace(AddingShip.FullNameOfCaptain) &&
                AddingShip.ShipType != null &&
                !string.IsNullOrWhiteSpace(AddingShip.PhotoPath) &&
                ShipHomePort != null)
            {
                if (AddingShip.Tonnage <= 0)
                {
                    MessageBox.Show("Грузоподъёмность должна быть положительным числом");
                }
                else
                {
                    if (AddingShip.YearOfBuilt < 1900 || AddingShip.YearOfBuilt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Год постройки должен быть между 1900 и текущим годом");
                    }
                    else
                    {
                        if (_shipCrud.ReadByName(AddingShip.Name) == null)
                        {
                            AddingShip.PortId = ShipHomePort.Id;
                            SelectedShip = AddingShip;
                            _shipCrud.Create(SelectedShip);
                            MessageBox.Show("Судно успешно добавлено");
                            FilteredShips.Add(SelectedShip);
                            ShipSelectedTabIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Это название уже используется");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private void SaveChangesShipCommand(object parameter)
    {
        
        if (!string.IsNullOrWhiteSpace(EditingShip.Name) &&
            !string.IsNullOrWhiteSpace(EditingShip.RegistrationNumber) &&
            !string.IsNullOrWhiteSpace(EditingShip.FullNameOfCaptain) &&
            EditingShip.ShipType != null &&
            !string.IsNullOrWhiteSpace(EditingShip.PhotoPath) &&
            EditingShip.PortId != null)
        {
            var existingShip = _shipCrud.ReadByName(EditingShip.Name);
            if (existingShip != null && existingShip.Id != SelectedShip.Id)
            {
                MessageBox.Show("Судно с таким названием уже существует");
            }
            else
            {
                if (EditingShip.Tonnage <= 0)
                {
                    MessageBox.Show("Грузоподъёмность должна быть положительным числом");
                }
                else
                {
                    if (EditingShip.YearOfBuilt < 1900 || EditingShip.YearOfBuilt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Год постройки должен быть между 1900 и текущим годом");
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать судно?", 
                            "Подтверждение", 
                            MessageBoxButton.YesNo, 
                            MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            SelectedShip = EditingShip;
                            _shipCrud.Update(SelectedShip);
                            FilteredShips.Replace(SelectedShip, SelectedShip);
                            MessageBox.Show("Судно успешно обновлено");
                            List<Ship> shipList = _shipCrud.ReadAll();
                            this.FilteredShips = new ObservableCollection<Ship>(shipList);
                            OnPropertyChanged(nameof(FilteredShips));
                            ShipSelectedTabIndex = 0;
                        }
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Все поля должны быть заполнены");
        }
    }

    private void ShipPerformSearch()
    {
        if (Ships == null)
            return;
        var filtered = Ships
            .Where(u => string.IsNullOrEmpty(SearchShipName) ||
                        u.Name.Contains(SearchShipName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredShips = new ObservableCollection<Ship>(filtered);

        // Уведомляем об изменении свойства FilteredShips
        OnPropertyChanged(nameof(FilteredShips)); 
    }
    
    private void ToggleTypeOfCargoForShipCommand(object parameter)
    {
        if (parameter is TypeOfCargo cargo)
        {
            if (SelectedTypesOfCargoForShip.Contains(cargo))
            {
                SelectedTypesOfCargoForShip.Remove(cargo); // Если уже выбран, снимаем выбор
            }
            else
            {
                SelectedTypesOfCargoForShip.Add(cargo); // Если не выбран, добавляем
            }

            OnPropertyChanged(nameof(SelectedTypesOfCargoForShip));
        }
    }
    
    private void DeleteTypeOfCargoCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить тип груза?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _typeOfCargoCrud.Delete(SelectedTypeOfCargo);
            FilteredPorts.Remove(SelectedPort);
            MessageBox.Show("Тип груза удалён");
            TypeOfCargoSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            TypeOfCargoSelectedTabIndex = 0;
        }
    }
    
    private void CreateTypeOfCargoCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(TypeOfCargoName))
        {
            if (_typeOfCargoCrud.ReadByName(TypeOfCargoName) == null)
            {
                SelectedTypeOfCargo = new TypeOfCargo(TypeOfCargoName);
                _typeOfCargoCrud.Create(SelectedTypeOfCargo);
                MessageBox.Show("Тип груза успешно добавлен");
                FilteredTypesOfCargo.Add(SelectedTypeOfCargo);
                TypeOfCargoSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesTypeOfCargoCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(TypeOfCargoName))
        {
            var existingTypeOfCargo = _typeOfCargoCrud.ReadByName(TypeOfCargoName);
            if (existingTypeOfCargo != null && existingTypeOfCargo.Id != SelectedTypeOfCargo.Id)
            {
                MessageBox.Show("Тип груза с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать тип груза?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SelectedTypeOfCargo.Name = TypeOfCargoName;
                    _typeOfCargoCrud.Update(SelectedTypeOfCargo);
                    FilteredTypesOfCargo.Replace(SelectedTypeOfCargo, SelectedTypeOfCargo);
                    MessageBox.Show("Тип груза успешно обновлён");
                    List<TypeOfCargo> typeOfCargoList =  _typeOfCargoCrud.ReadAll();
                    this.FilteredTypesOfCargo = new ObservableCollection<TypeOfCargo>(typeOfCargoList);
                    OnPropertyChanged(nameof(FilteredTypesOfCargo));
                    TypeOfCargoSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void TypeOfCargoPerformSearch()
    {
        if (TypesOfCargo == null)
            return;
        var filtered = TypesOfCargo
            .Where(u => string.IsNullOrEmpty(SearchTypeOfCargoName) ||
                        u.Name.Contains(SearchTypeOfCargoName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredTypesOfCargo = new ObservableCollection<TypeOfCargo>(filtered);

        // Уведомляем об изменении свойства FilteredStreets
        OnPropertyChanged(nameof(FilteredTypesOfCargo));
    }
    
    private void DeleteUnitOfMeasurementCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить единицу измерения?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            // Действие при выборе "Да"
            _unitOfMeasurementCrud.Delete(SelectedUnitOfMeasurement);
            FilteredUnitsOfMeasurement.Remove(SelectedUnitOfMeasurement);
            MessageBox.Show("Единица измерения удалена");
            UnitOfMeasurementSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            UnitOfMeasurementSelectedTabIndex = 0;
        }
    }
    
    private void CreateUnitOfMeasurementCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(UnitOfMeasurementName))
        {
            if (_unitOfMeasurementCrud.ReadByName(UnitOfMeasurementName) == null)
            {
                SelectedUnitOfMeasurement = new UnitOfMeasurement(UnitOfMeasurementName);
                _unitOfMeasurementCrud.Create(SelectedUnitOfMeasurement);
                MessageBox.Show("Единица измерения успешно добавлена");
                FilteredUnitsOfMeasurement.Add(SelectedUnitOfMeasurement);
                UnitOfMeasurementSelectedTabIndex = 0;
            }
            else
            {
                MessageBox.Show("Это название уже используется");
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым!");
        }
    }
    
    private void SaveChangesUnitOfMeasurementCommand(object parameter)
    {
        if (!string.IsNullOrWhiteSpace(UnitOfMeasurementName))
        {
            var existingUnitOfMeasurement = _unitOfMeasurementCrud.ReadByName(UnitOfMeasurementName);
            if (existingUnitOfMeasurement != null && existingUnitOfMeasurement.Id != SelectedUnitOfMeasurement.Id)
            {
                MessageBox.Show("Единица измерения с таким названием уже существует");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать единицу измерения?", 
                    "Подтверждение", 
                    MessageBoxButton.YesNo, 
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    SelectedUnitOfMeasurement.Name = UnitOfMeasurementName;
                    _unitOfMeasurementCrud.Update(SelectedUnitOfMeasurement);
                    FilteredUnitsOfMeasurement.Replace(SelectedUnitOfMeasurement, SelectedUnitOfMeasurement);
                    MessageBox.Show("Единица измерения успешно обновлена!");
                    List<UnitOfMeasurement> unitOfMeasurementList =  _unitOfMeasurementCrud.ReadAll();
                    this.FilteredUnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(unitOfMeasurementList);
                    OnPropertyChanged(nameof(FilteredUnitsOfMeasurement));
                    UnitOfMeasurementSelectedTabIndex = 0;
                }
            }
        }
        else
        {
            MessageBox.Show("Название не может быть пустым");
        }
    }

    private void UnitOfMeasurementPerformSearch()
    {
        if (UnitsOfMeasurement == null)
            return;
        var filtered = UnitsOfMeasurement
            .Where(u => string.IsNullOrEmpty(SearchUnitOfMeasurementName) ||
                        u.Name.Contains(SearchUnitOfMeasurementName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredUnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(filtered);

        // Уведомляем об изменении свойства FilteredStreets
        OnPropertyChanged(nameof(FilteredUnitsOfMeasurement));
    }
    
     private void DeleteVoyageCommand(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить рейс?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            _voyageCrud.Delete(SelectedVoyage);
            FilteredVoyages.Remove(SelectedVoyage);
            MessageBox.Show("Рейс удалён");
            VoyageSelectedTabIndex = 0;
        }
        else if (result == MessageBoxResult.No)
        {
            VoyageSelectedTabIndex = 0;
        }
    }
    private void CreateVoyageCommand(object parameter)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(AddingShip.Name) &&
                !string.IsNullOrWhiteSpace(AddingShip.RegistrationNumber) &&
                !string.IsNullOrWhiteSpace(AddingShip.FullNameOfCaptain) &&
                AddingShip.ShipType != null &&
                !string.IsNullOrWhiteSpace(AddingShip.PhotoPath) &&
                ShipHomePort != null)
            {
                if (AddingShip.Tonnage <= 0)
                {
                    MessageBox.Show("Грузоподъёмность должна быть положительным числом");
                }
                else
                {
                    if (AddingShip.YearOfBuilt < 1900 || AddingShip.YearOfBuilt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Год постройки должен быть между 1900 и текущим годом");
                    }
                    else
                    {
                        if (_shipCrud.ReadByName(AddingShip.Name) == null)
                        {
                            AddingShip.PortId = ShipHomePort.Id;
                            SelectedShip = AddingShip;
                            _shipCrud.Create(SelectedShip);
                            MessageBox.Show("Судно успешно добавлено");
                            FilteredShips.Add(SelectedShip);
                            ShipSelectedTabIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("Это название уже используется");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"Name: {AddingShip.Name}");
                Console.WriteLine($"RegistrationNumber: {AddingShip.RegistrationNumber}");
                Console.WriteLine($"FullNameOfCaptain: {AddingShip.FullNameOfCaptain}");
                Console.WriteLine($"ShipType: {AddingShip.ShipType}");
                Console.WriteLine($"Tonnage: {AddingShip.Tonnage}");
                Console.WriteLine($"YearOfBuilt: {AddingShip.YearOfBuilt}");
                Console.WriteLine($"PhotoPath: {AddingShip.PhotoPath}");
                Console.WriteLine($"PortId: {AddingShip.PortId}");
                Console.WriteLine($"Port (Name): {AddingShip.Port?.Name}");
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private void SaveChangesVoyageCommand(object parameter)
    {
        
        if (!string.IsNullOrWhiteSpace(EditingShip.Name) &&
            !string.IsNullOrWhiteSpace(EditingShip.RegistrationNumber) &&
            !string.IsNullOrWhiteSpace(EditingShip.FullNameOfCaptain) &&
            EditingShip.ShipType != null &&
            !string.IsNullOrWhiteSpace(EditingShip.PhotoPath) &&
            EditingShip.PortId != null)
        {
            var existingShip = _shipCrud.ReadByName(EditingShip.Name);
            if (existingShip != null && existingShip.Id != SelectedShip.Id)
            {
                MessageBox.Show("Судно с таким названием уже существует");
            }
            else
            {
                if (EditingShip.Tonnage <= 0)
                {
                    MessageBox.Show("Грузоподъёмность должна быть положительным числом");
                }
                else
                {
                    if (EditingShip.YearOfBuilt < 1900 || EditingShip.YearOfBuilt > DateTime.Now.Year)
                    {
                        MessageBox.Show("Год постройки должен быть между 1900 и текущим годом");
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите редактировать судно?", 
                            "Подтверждение", 
                            MessageBoxButton.YesNo, 
                            MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            SelectedShip = EditingShip;
                            _shipCrud.Update(SelectedShip);
                            FilteredShips.Replace(SelectedShip, SelectedShip);
                            MessageBox.Show("Судно успешно обновлено");
                            List<Ship> shipList = _shipCrud.ReadAll();
                            this.FilteredShips = new ObservableCollection<Ship>(shipList);
                            OnPropertyChanged(nameof(FilteredShips));
                            ShipSelectedTabIndex = 0;
                        }
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Все поля должны быть заполнены");
        }
    }

    private void SaveChangesInGridVoyageCommand(object para)
    {
        try
        {
            _shipmentCrud.UpdateRange(ShipmentForVoyage);
            MessageBox.Show("Изменения успешно сохранены.", 
                "Успех", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных:\n{ex.Message}", 
                "Ошибка", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error);
        }
    }

    private void AddShipmentForVoyageCommand(object parameter)
    {
        if (AddShipmentIdForVoyage <= 0)
        {
            MessageBox.Show("Введите корректный идентификатор.");
            return;
        }

        try
        {
            // Проверяем, существует ли партия груза с таким Id
            var existingShipment = _shipmentCrud.ReadById(AddShipmentIdForVoyage);
            if (existingShipment == null)
            {
                // Если запись не найдена, показываем сообщение и выходим
                MessageBox.Show($"Партия груза с Id = {AddShipmentIdForVoyage} не найдена.");
                return;
            }

            // Проверяем, не добавлена ли уже партия груза в таблицу
            if (ShipmentForVoyage.Any(s => s.Id == existingShipment.Id))
            {
                MessageBox.Show("Партия груза уже добавлена в таблицу.");
                return;
            }

            // Привязываем к текущему рейсу
            existingShipment.VoyageId = EditingVoyage.Id;

            // Обновляем запись в базе данных
            _shipmentCrud.Update(existingShipment);

            // Добавляем в коллекцию
            ShipmentForVoyage.Add(existingShipment);
            MessageBox.Show($"Партия груза с Id = {AddShipmentIdForVoyage} успешно добавлена.");
        }
        catch (Exception ex)
        {
            // Обработка непредвиденных ошибок
            MessageBox.Show($"Произошла ошибка при добавлении партии груза: {ex.Message}");
        }

        // Сбрасываем введённое значение
        AddShipmentIdForVoyage = 0;
    }

    private void AddPortInVoyageCommand(object parameter)
    {
        if (SelectedNewPortInVoyage == null)
        {
            MessageBox.Show("Выберите порт для добавления.");
            return;
        }

        if (EditingVoyage.VoyagePorts.Any(vp => vp.PortId == SelectedNewPortInVoyage.Id))
        {
            MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} уже существует в списке промежуточных портов данного рейса.");
            return;
        }

        try
        {
            // Создаём один экземпляр VoyagePort
            var newVoyagePort = new VoyagePort(EditingVoyage.Id, SelectedNewPortInVoyage.Id);

            // Добавляем в базу данных
            _voyagePortCrud.Create(newVoyagePort);

            // Добавляем в локальный список
            EditingVoyage.VoyagePorts.Add(newVoyagePort);

            // Уведомляем об изменениях
            OnPropertyChanged(nameof(EditingVoyage.VoyagePorts));
            MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} добавлен.");
        }
        catch (Exception e)
        {
            MessageBox.Show($"Ошибка при добавлении порта: {e.Message}");
        }
    }

    private void VoyageIdPerformSearch()
    {
        if (Ships == null)
            return;
        var filtered = Ships
            .Where(u => string.IsNullOrEmpty(SearchShipName) ||
                        u.Name.Contains(SearchShipName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredShips = new ObservableCollection<Ship>(filtered);

        // Уведомляем об изменении свойства FilteredShips
        OnPropertyChanged(nameof(FilteredShips)); 
    }
}