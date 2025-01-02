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
    public ObservableCollection<ClientCompany> Clients { get; set; }
    public ObservableCollection<ClientCompany> FilteredClients { get; set; }
    public ObservableCollection<Cargo> Cargoes { get; set; }
    public ObservableCollection<Voyage> Voyages { get; set; }
    public ObservableCollection<Voyage> FilteredVoyages { get; set; }
    private ObservableCollection<Port> _portsForVoyage;

    public ObservableCollection<Port> PortsForVoyage
    {
        get => _portsForVoyage;
        set
        {
            _portsForVoyage = value;
            OnPropertyChanged();
        }
    }
    

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
    public ICommand ClientButton { get; }
    
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
    private readonly CargoCrud _cargoCrud = new CargoCrud();
    
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
    public ICommand DeletePortInVoyageButton { get; }
    public ICommand DeleteShipmentForVoyageButton { get; }
    private int _voyageSelectedTabIndex;
    public bool IsVoyageSelected => SelectedVoyage != null;
    public bool IsPortForVoyageSelected => SelectedPortForVoyageDelete != null;
    private long _addShipmentIdForVoyage;
    private Port _selectedNewPortInVoyage;
    private Voyage _selectedVoyage;
    private Port _selectedPortForVoyageDelete;
    private Voyage _editingVoyage;
    private Voyage _addingVoyage;
    private string _searchVoyageId;
    private Shipment _selectedShipmentForVoyage;
    private Port _selectedSourcePortInVoyage;
    private Port _selectedDestinationPortInVoyage;
    private Ship _selectedShipForVoyage;
    public ObservableCollection<VoyagePort> AddingVoyagePorts;
    
    public Ship SelectedShipForVoyage
    {
        get => _selectedShipForVoyage;
        set
        {
            if (_selectedShipForVoyage != value)
            {
                _selectedShipForVoyage = value;
                OnPropertyChanged();
            }
        }
    }
    public Port SelectedDestinationPortInVoyage
    {
        get => _selectedDestinationPortInVoyage;
        set
        {
            if (_selectedDestinationPortInVoyage != value)
            {
                _selectedDestinationPortInVoyage = value;
                OnPropertyChanged();

                if (EditingVoyage != null)
                {
                    EditingVoyage.DestinationPort = _selectedDestinationPortInVoyage;
                    OnPropertyChanged(nameof(EditingVoyage.DestinationPort));
                }
            }
        }
    } 
    public Port SelectedSourcePortInVoyage
    {
        get => _selectedSourcePortInVoyage;
        set
        {
            if (_selectedSourcePortInVoyage != value)
            {
                _selectedSourcePortInVoyage = value;
                OnPropertyChanged();

                // Обновление SourcePort у EditingVoyage
                if (EditingVoyage != null)
                {
                    EditingVoyage.SourcePort = _selectedSourcePortInVoyage;
                    OnPropertyChanged(nameof(EditingVoyage.SourcePort));
                }
            }
        }
    }
    public Shipment SelectedShipmentForVoyage
    {
        get => _selectedShipmentForVoyage;
        set
        {
            
            _selectedShipmentForVoyage = value;
            OnPropertyChanged();
            Console.WriteLine($"SelectedShipmentForVoyage: {_selectedShipmentForVoyage?.Id}");
        }
    }
    public Port SelectedPortForVoyageDelete
    {
        get => _selectedPortForVoyageDelete;
        set
        {
            if (_selectedPortForVoyageDelete != value)
            {
                _selectedPortForVoyageDelete = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPortForVoyageSelected));
            }
        }
    }
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
                    SelectedShipForVoyage = null;
                    SelectedSourcePortInVoyage = null;
                    List<Shipment> shipmentsForVoyageList = _shipmentCrud.ReadByVoyageId(SelectedVoyage.Id);
                    ShipmentForVoyage = new ObservableCollection<Shipment>(shipmentsForVoyageList);
                    PortsForVoyage = _voyagePortCrud.ReadPortsByVoyageId(SelectedVoyage.Id);
                    Console.WriteLine("_voyageSelectedTabIndex == 1 || _voyageSelectedTabIndex == 2");
                    foreach (Shipment shipment in ShipmentForVoyage)
                    {
                        shipment.ReceivingCompany = _clientCompanyCrud.ReadById(shipment.ReceivingCompanyId.Value);
                        shipment.SendingCompany = _clientCompanyCrud.ReadById(shipment.SendingCompanyId.Value);
                    }
                    if (_voyageSelectedTabIndex == 2)
                    {
                        EditingVoyage = SelectedVoyage;
                        OnPropertyChanged(nameof(PortsForVoyage));
                    }
                    
                }
                if (_voyageSelectedTabIndex == 3)
                {
                    PortsForVoyage.Clear();
                    SelectedShipForVoyage = null;
                    SelectedSourcePortInVoyage = null;
                    ShipmentForVoyage = new ObservableCollection<Shipment>();
                    AddingVoyage = new Voyage();
                    SelectedShip = null;
                        
                    Console.WriteLine("AddingVoyage инициализирован.");
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
    
    // Атрибуты ClientCompaniesListControl
    private ObservableCollection<Shipment> _shipmentForClient;
    public ObservableCollection<Shipment> ShipmentForClient
    {
        get => _shipmentForClient;
        set
        {
            _shipmentForClient = value;
            OnPropertyChanged(nameof(ShipmentForClient)); // Уведомляем об изменении свойства
        }
    }
    public ICommand DeleteClientButton { get; }
    public ICommand CreateClientButton { get; }
    public ICommand SaveChangesClientButton { get; }
    public ICommand CreateShipmentButton { get; }
    public ICommand SaveChangesShipmentButton { get; }
    public ICommand DeleteShipmentButton { get; }
    public ICommand CreateCargoButton { get; }
    public ICommand SaveChangesCargoButton { get; }
    public ICommand DeleteCargoButton { get; }
    private int _clientSelectedTabIndex;
    private int _clientInformationSelectedTabIndex;
    public bool IsClientSelected => SelectedClient != null;
    public bool IsSelectedShipmentForClient => SelectedShipmentForClient != null;
    public bool IsSelectedCargo => SelectedCargo != null;
    private ClientCompany _selectedClient;
    private ClientCompany _editingClient;
    private string _searchClientName;
    private Shipment _selectedShipmentForClient;
    private Cargo _selectedCargo;
    private Port _sourcePort;
    private Port _destinationPort;
    private ClientCompany _sendingCompany;
    private ClientCompany _receivingCompany;
    public ObservableCollection<Cargo> CargoesForShipment { get; set; }

    public ClientCompany SendingCompany
    {
        get => _sendingCompany;
        set
        {
            _sendingCompany = value;
            OnPropertyChanged();
        }
    }

    public ClientCompany ReceivingCompany
    {
        get => _receivingCompany;
        set
        {
            _receivingCompany = value;
            OnPropertyChanged();
        }
    }
    public Port SourcePort
    {
        get => _sourcePort;
        set
        {
            _sourcePort = value;
            OnPropertyChanged();
        }
    }

    public Port DestinationPort
    {
        get => _destinationPort;
        set
        {
            _destinationPort = value;
            OnPropertyChanged();
        }
    }
    public Cargo SelectedCargo
    {
        get => _selectedCargo;
        set
        {
            _selectedCargo = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsSelectedCargo));
        }
    }
    public int ClientInformationSelectedTabIndex
    {
        get => _clientInformationSelectedTabIndex;
        set
        {
            if (_clientInformationSelectedTabIndex != value)
            {
                _clientInformationSelectedTabIndex = value;
                OnPropertyChanged();
                if (_clientInformationSelectedTabIndex == 1)
                {
                    CargoesForShipment = _cargoCrud.ReadByShipmentId(SelectedShipmentForClient.Id);
                }
            }
        }
    }
    public int ClientSelectedTabIndex
    {
        get => _clientSelectedTabIndex;
        set
        {
            if (_clientSelectedTabIndex != value)
            {
                _clientSelectedTabIndex = value;
                OnPropertyChanged();
                if (_clientSelectedTabIndex == 1)
                {
                    
                }
                if (_clientSelectedTabIndex == 2)
                {
                    _clientInformationSelectedTabIndex = 0;
                    EditingClient = SelectedClient;
                    OnPropertyChanged(nameof(EditingClient));
                }
            }
        }
    }
    public string SearchClientName
    {
        get => _searchClientName;
        set
        {
            if (_searchClientName != value)
            {
                _searchClientName = value;
                OnPropertyChanged();
                // ClientNamePerformSearch(); // Автоматическое выполнение поиска при изменении текста
            }
        }
    }
    public ClientCompany SelectedClient
    {
        get => _selectedClient;
        set
        {
            _selectedClient = value;
            ShipmentForClient = _shipmentCrud.ReadByCompanyIds(_selectedClient.Id);
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsClientSelected));
        }
    }

    public ClientCompany EditingClient
    {
        get => _editingClient;
        set
        {
            _editingClient = value;
            OnPropertyChanged();
        }
    }
    public Shipment SelectedShipmentForClient
    {
        get => _selectedShipmentForClient;
        set
        {
            _selectedShipmentForClient = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsSelectedShipmentForClient));
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
        ClientButton = new RelayCommand(ClientCommand);
        
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
        
        // Для UnitOfMeasurementListControl
        List<UnitOfMeasurement> unitsOfMeasurementList = _unitOfMeasurementCrud.ReadAll();
        this.UnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(unitsOfMeasurementList);
        FilteredUnitsOfMeasurement = new ObservableCollection<UnitOfMeasurement>(UnitsOfMeasurement);
        DeleteUnitOfMeasurementButton = new RelayCommand(DeleteUnitOfMeasurementCommand);
        CreateUnitOfMeasurementButton = new RelayCommand(CreateUnitOfMeasurementCommand);
        SaveChangesUnitOfMeasurementButton = new RelayCommand(SaveChangesUnitOfMeasurementCommand);
        
        // Для VoyagesGridControl
        List<Voyage> voyagesList = _voyageCrud.ReadAll();
        this.Voyages = new ObservableCollection<Voyage>(voyagesList);
        FilteredVoyages = new ObservableCollection<Voyage>(Voyages);
        PortsForVoyage = new ObservableCollection<Port>();
        DeleteVoyageButton = new RelayCommand(DeleteVoyageCommand);
        CreateVoyageButton = new RelayCommand(CreateVoyageCommand);
        SaveChangesVoyageButton = new RelayCommand(SaveChangesVoyageCommand);
        SaveChangesInGridVoyageButton = new RelayCommand(SaveChangesInGridVoyageCommand);
        AddShipmentForVoyageButton = new RelayCommand(AddShipmentForVoyageCommand);
        AddPortInVoyageButton = new RelayCommand(AddPortInVoyageCommand);
        DeletePortInVoyageButton = new RelayCommand(DeletePortInVoyageCommand);
        DeleteShipmentForVoyageButton = new RelayCommand(DeleteShipmentForVoyage);
        
        // Для ClientCompaniesListControl
        List<ClientCompany> clientCompaniesList = _clientCompanyCrud.ReadAll();
        this.Clients = new ObservableCollection<ClientCompany>(clientCompaniesList);
        FilteredClients = new ObservableCollection<ClientCompany>(Clients);
        CreateClientButton = new RelayCommand(CreateClientCommand);
        SaveChangesClientButton = new RelayCommand(SaveChangesClientCommand);
        DeleteClientButton = new RelayCommand(DeleteClientCommand);
        CreateShipmentButton = new RelayCommand(CreateShipmentCommand);
        SaveChangesShipmentButton = new RelayCommand(SaveChangesShipmentCommand);
        DeleteShipmentButton = new RelayCommand(DeleteShipmentCommand);
        CreateCargoButton = new RelayCommand(CreateCargoCommand);
        SaveChangesCargoButton = new RelayCommand(SaveChangesCargoCommand);
        DeleteCargoButton = new RelayCommand(DeleteCargoCommand);
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
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
        ClientCompaniesListControlVisible = Visibility.Collapsed;
        VoyagesGridControlVisible = Visibility.Visible;
    }

    private void ClientCommand(object parameter)
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
        VoyagesGridControlVisible = Visibility.Collapsed;
        ClientCompaniesListControlVisible = Visibility.Visible;
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
                    Users.Add(SelectedUser);
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
        MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить рейс №{SelectedVoyage.Id}?", 
            "Подтверждение", 
            MessageBoxButton.YesNo, 
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            try
            {
                ObservableCollection<Port> portsForVoyageDelete = _voyagePortCrud.ReadPortsByVoyageId(SelectedVoyage.Id);
                if(portsForVoyageDelete != null) _voyagePortCrud.DeleteByVoyageId(SelectedVoyage.Id);
                _voyageCrud.Delete(SelectedVoyage);
                FilteredVoyages.Remove(SelectedVoyage);
                MessageBox.Show("Рейс удалён");
                VoyageSelectedTabIndex = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
            Console.WriteLine(SelectedShipForVoyage.Name);
            Console.WriteLine(AddingVoyage);
            if (SelectedShipForVoyage == null)
            {
                MessageBox.Show("Выберите судно");
                return;
            }

            if (SelectedSourcePortInVoyage == null)
            {
                MessageBox.Show("Выберите порт отправления");
                return;
            }

            if (SelectedDestinationPortInVoyage == null)
            {
                MessageBox.Show("Выберите порт назначения");
                return;
            }
            AddingVoyage.Ship = SelectedShipForVoyage;
            AddingVoyage.SourcePort = SelectedSourcePortInVoyage;
            AddingVoyage.DestinationPort = SelectedDestinationPortInVoyage;
            _voyageCrud.Create(AddingVoyage);
            SelectedVoyage = AddingVoyage;
            Voyages.Add(SelectedVoyage);
            FilteredVoyages.Add(SelectedVoyage);
            OnPropertyChanged(nameof(FilteredVoyages));
            MessageBox.Show("Рейс успешно создан!");
            VoyageSelectedTabIndex = 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    private void SaveChangesVoyageCommand(object parameter)
    {
        try
        {
            // Проверяем наличие объекта EditingVoyage
            if (EditingVoyage == null)
            {
                MessageBox.Show("Редактируемый рейс не найден.");
                return;
            }

            // Проверяем обязательные поля рейса
            if (!ValidatePorts()) return;
            if (!ValidateDates()) return;

            // Подтверждение сохранения изменений
            if (MessageBox.Show("Вы уверены, что хотите сохранить изменения рейса?",
                                "Подтверждение",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                // Сохраняем изменения, если они есть
                UpdateVoyageFields();

                // Сохраняем изменения в базе данных
                _voyageCrud.Update(EditingVoyage);

                OnPropertyChanged(nameof(SelectedVoyage));
                MessageBox.Show("Изменения успешно сохранены.");
                ShipSelectedTabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Неожиданная ошибка: {e.Message}");
        }
    }

    /// <summary>
    /// Проверяет корректность портов рейса.
    /// </summary>
    private bool ValidatePorts()
    {
        if (EditingVoyage.SourcePort == null)
        {
            MessageBox.Show("Порт отправления не указан.");
            return false;
        }

        if (EditingVoyage.DestinationPort == null)
        {
            MessageBox.Show("Порт назначения не указан.");
            return false;
        }

        if (EditingVoyage.SourcePort.Id == EditingVoyage.DestinationPort.Id)
        {
            MessageBox.Show("Порт отправления и порт назначения не могут быть одинаковыми.");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Проверяет корректность дат рейса.
    /// </summary>
    private bool ValidateDates()
    {
        if (!EditingVoyage.DepartureDate.HasValue)
        {
            MessageBox.Show("Дата отбытия не указана.");
            return false;
        }

        if (!EditingVoyage.ArrivalDate.HasValue)
        {
            MessageBox.Show("Дата прибытия не указана.");
            return false;
        }
        
        if (EditingVoyage.ArrivalDate.Value < EditingVoyage.DepartureDate.Value)
        {
            MessageBox.Show("Дата прибытия не может быть раньше даты отбытия.");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Обновляет поля EditingVoyage, если они изменились.
    /// </summary>
    private void UpdateVoyageFields()
    {
        if (SelectedShipForVoyage != null && 
            (EditingVoyage.Ship == null || EditingVoyage.Ship.Name != SelectedShipForVoyage.Name))
        {
            EditingVoyage.Ship = SelectedShipForVoyage;
        }
        
        if (EditingVoyage.SourcePort != SelectedSourcePortInVoyage && SelectedSourcePortInVoyage != null)
        {
            EditingVoyage.SourcePort = SelectedSourcePortInVoyage;
            OnPropertyChanged(nameof(EditingVoyage));
        }

        if (EditingVoyage.DestinationPort != SelectedDestinationPortInVoyage && SelectedDestinationPortInVoyage != null)
        {
            EditingVoyage.DestinationPort = SelectedDestinationPortInVoyage;
            OnPropertyChanged(nameof(EditingVoyage));
        }
    }
    
    private void DeleteShipmentForVoyage(object parameter)
    {
        try
        {
            // Проверка на выбор партии груза
            if (SelectedShipmentForVoyage == null)
            {
                MessageBox.Show("Выберите партию груза для удаления.");
                return;
            }

            // Подтверждение удаления
            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить партию груза №{SelectedShipmentForVoyage.Id} из рейса?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Удаление связи рейс-партия груза
                    SelectedShipmentForVoyage.VoyageId = null;
                    _shipmentCrud.Update(SelectedShipmentForVoyage);

                    // Удаление из коллекции и обновление интерфейса
                    ShipmentForVoyage.Remove(SelectedShipmentForVoyage);
                    OnPropertyChanged(nameof(ShipmentForVoyage));

                    MessageBox.Show("Партия груза успешно удалена из рейса.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при обновлении данных в базе данных: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            // Общий обработчик ошибок
            MessageBox.Show($"Произошла ошибка: {ex.Message}");
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
                MessageBox.Show($"Партия груза под номером {AddShipmentIdForVoyage} не найдена.");
                return;
            }

            // Проверяем, привязана ли партия груза к другому рейсу
            if (existingShipment.VoyageId != null && existingShipment.VoyageId != EditingVoyage.Id)
            {
                var result = MessageBox.Show(
                    $"Партия груза под номером {existingShipment.Id} уже привязана к  другому рейсу." +
                    $" Хотите открепить её от рейса под номером {existingShipment.VoyageId} по прикрепить к текущему?",
                    "Подтверждение",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result != MessageBoxResult.Yes)
                {
                    // Если пользователь отказался, выходим
                    return;
                }
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
            MessageBox.Show($"Партия груза под номером {AddShipmentIdForVoyage} успешно добавлена.");
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
        Console.WriteLine($"VoyageSelectedTabIndex: {VoyageSelectedTabIndex}");

        if (SelectedNewPortInVoyage == null)
        {
            MessageBox.Show("Выберите порт для добавления.");
            return;
        }

        if (VoyageSelectedTabIndex == 2)
        {
            try
            {
                // Проверка на существование в базе данных
                if (_voyagePortCrud.ReadAll().Any(vp => vp.VoyageId == EditingVoyage.Id && vp.PortId == SelectedNewPortInVoyage.Id))
                {
                    MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} уже связан с рейсом в базе данных.");
                    return;
                }

                // Создаём экземпляр VoyagePort
                var newVoyagePort = new VoyagePort(EditingVoyage.Id, SelectedNewPortInVoyage.Id);

                // Добавляем в базу данных
                _voyagePortCrud.Create(newVoyagePort);

                // Добавляем в локальный список
                PortsForVoyage.Add(SelectedNewPortInVoyage);
                OnPropertyChanged(nameof(PortsForVoyage));

                MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} добавлен.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при добавлении порта: {e.Message}");
            }
        }
        else if (VoyageSelectedTabIndex == 3)
        {
            Console.WriteLine(SelectedNewPortInVoyage);
            try
            {
                if (PortsForVoyage != null)
                {
                    // Проверка на существование в локальном списке
                    if (PortsForVoyage.Any(p => p.Id == SelectedNewPortInVoyage.Id))
                    {
                        MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} уже добавлен.");
                        return;
                    }

                    // Добавляем порт в список
                    PortsForVoyage.Add(SelectedNewPortInVoyage);
                    OnPropertyChanged(nameof(PortsForVoyage));

                    MessageBox.Show($"Порт {SelectedNewPortInVoyage.Name} добавлен.");
                    Console.WriteLine($"PortsForVoyage.Cont = {PortsForVoyage.Count}");
                }
                else
                {
                    MessageBox.Show("PortsForVoyage инициализирована как null.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при добавлении порта: {e.Message}");
            }
        }
    }
    
    private void DeletePortInVoyageCommand(object parameter)
    {
        // Проверяем, выбран ли порт для удаления
        if (SelectedPortForVoyageDelete == null)
        {
            MessageBox.Show("Выберите порт для удаления из рейса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Проверяем, установлен ли рейс
        if (EditingVoyage == null)
        {
            MessageBox.Show("Рейс не установлен. Пожалуйста, выберите рейс.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Подтверждение удаления
        var result = MessageBox.Show(
            $"Вы уверены, что хотите удалить порт '{SelectedPortForVoyageDelete.Name}' из рейса?",
            "Подтверждение удаления",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning
        );

        if (result == MessageBoxResult.Yes)
        {
            try
            {
                // Проверяем, есть ли коллекция портов
                if (PortsForVoyage == null)
                {
                    MessageBox.Show("Список портов для рейса не инициализирован.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                // Удаление связки рейс-порт
                _voyagePortCrud.Delete(new VoyagePort(EditingVoyage.Id, SelectedPortForVoyageDelete.Id));
                MessageBox.Show($"Порт '{SelectedPortForVoyageDelete.Name}' успешно удалён из рейса.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                // Обновляем коллекцию портов
                PortsForVoyage.Remove(SelectedPortForVoyageDelete);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                OnPropertyChanged(nameof(PortsForVoyage));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    private void VoyageIdPerformSearch()
    {
        if (Voyages == null)
            return;
        var filtered = Voyages
            .Where(u => string.IsNullOrEmpty(SearchVoyageId) ||
                        u.Id.ToString().Contains(SearchVoyageId, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Заменяем всю коллекцию, чтобы вызвать обновление привязки
        FilteredVoyages = new ObservableCollection<Voyage>(filtered);

        // Уведомляем об изменении свойства FilteredShips
        OnPropertyChanged(nameof(FilteredVoyages)); 
    }

    private void CreateClientCommand(object parameter)
    {
        
    }
    private void SaveChangesClientCommand(object parameter)
    {
        
    }

    private void DeleteClientCommand(object parameter)
    {
        
    }
    private void CreateShipmentCommand(object parameter)
    {
        try
        {
            if (ShipmentForClient == null || ShipmentForClient.Count == 0)
            {
                MessageBox.Show("Список партий груза пуст или не инициализирован.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        
            foreach (Shipment shipment in ShipmentForClient)
            {
                if (shipment == null)
                {
                    MessageBox.Show("Обнаружена пустая запись в списке партий груза.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    continue;
                }
        
                if (shipment.Id == 0)
                {
                    // SendingCompany
                    if (shipment.SendingCompany == null)
                    {
                        Console.WriteLine("SendingCompany is null");
                    }
                    else if (string.IsNullOrEmpty(shipment.SendingCompany.Name))
                    {
                        Console.WriteLine("SendingCompany.Name is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"SendingCompany.Name: {shipment.SendingCompany.Name}");
                    }

                    // ReceivingCompany
                    if (shipment.ReceivingCompany == null)
                    {
                        Console.WriteLine("ReceivingCompany is null");
                    }
                    else if (string.IsNullOrEmpty(shipment.ReceivingCompany.Name))
                    {
                        Console.WriteLine("ReceivingCompany.Name is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"ReceivingCompany.Name: {shipment.ReceivingCompany.Name}");
                    }

                    // VoyageId
                    if (shipment.VoyageId == null)
                    {
                        Console.WriteLine("VoyageId is null");
                    }
                    else
                    {
                        Console.WriteLine($"VoyageId: {shipment.VoyageId}");
                    }

                    // SourcePort
                    if (shipment.SourcePort == null)
                    {
                        Console.WriteLine("SourcePort is null");
                    }
                    else if (string.IsNullOrEmpty(shipment.SourcePort.Name))
                    {
                        Console.WriteLine("SourcePort.Name is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"SourcePort.Name: {shipment.SourcePort.Name}");
                    }

                    // DestinationPort
                    if (shipment.DestinationPort == null)
                    {
                        Console.WriteLine("DestinationPort is null");
                    }
                    else if (string.IsNullOrEmpty(shipment.DestinationPort.Name))
                    {
                        Console.WriteLine("DestinationPort.Name is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"DestinationPort.Name: {shipment.DestinationPort.Name}");
                    }

                    // CustomsBatchNumber
                    if (string.IsNullOrEmpty(shipment.CustomsBatchNumber))
                    {
                        Console.WriteLine("CustomsBatchNumber is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"CustomsBatchNumber: {shipment.CustomsBatchNumber}");
                    }

                    // CustomsDeclarationNumber
                    if (string.IsNullOrEmpty(shipment.CustomsDeclarationNumber))
                    {
                        Console.WriteLine("CustomsDeclarationNumber is null or empty");
                    }
                    else
                    {
                        Console.WriteLine($"CustomsDeclarationNumber: {shipment.CustomsDeclarationNumber}");
                    }

                    // DepartureDate
                    if (shipment.DepartureDate == null)
                    {
                        Console.WriteLine("DepartureDate is null");
                    }
                    else
                    {
                        Console.WriteLine($"DepartureDate: {shipment.DepartureDate:yyyy-MM-dd}");
                    }

                    // ArrivalDate
                    if (shipment.ArrivalDate == null)
                    {
                        Console.WriteLine("ArrivalDate is null");
                    }
                    else
                    {
                        Console.WriteLine($"ArrivalDate: {shipment.ArrivalDate:yyyy-MM-dd}");
                    }
                    // Проверки на обязательные поля
                    if (string.IsNullOrWhiteSpace(shipment.CustomsBatchNumber))
                    {
                        MessageBox.Show("Введите таможенный номер.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    if (string.IsNullOrWhiteSpace(shipment.CustomsDeclarationNumber))
                    {
                        MessageBox.Show("Введите номер таможенной декларации.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    if (shipment.SendingCompany == null || string.IsNullOrWhiteSpace(shipment.SendingCompany.Name))
                    {
                        MessageBox.Show("Укажите корректную компанию отправителя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    if (shipment.ReceivingCompany == null || string.IsNullOrWhiteSpace(shipment.ReceivingCompany.Name))
                    {
                        MessageBox.Show("Укажите корректную компанию получателя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    ClientCompany sendingCompany = _clientCompanyCrud.ReadByCompanyName(shipment.SendingCompany.Name);
                    if (sendingCompany != null)
                    {
                        shipment.SendingCompanyId = sendingCompany.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Не найдена указанная компания отправителя: {shipment.SendingCompany.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }

                    ClientCompany receivingCompany = _clientCompanyCrud.ReadByCompanyName(shipment.ReceivingCompany.Name);
                    if (receivingCompany != null)
                    {
                        shipment.ReceivingCompanyId = receivingCompany.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Не найдена указанная компания получателя: {shipment.ReceivingCompany.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    // Присваиваем идентификаторы для SourcePort
                    if (shipment.SourcePort == null || string.IsNullOrEmpty(shipment.SourcePort.Name))
                    {
                        MessageBox.Show("Укажите корректный порт отправления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    var sourcePort = Ports.FirstOrDefault(port => port.Name == shipment.SourcePort.Name);
                    if (sourcePort != null)
                    {
                        shipment.SourcePortId = sourcePort.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Не найден указанный порт отправления: {shipment.SourcePort.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }

                    // Присваиваем идентификаторы для DestinationPort
                    if (shipment.DestinationPort == null || string.IsNullOrEmpty(shipment.DestinationPort.Name))
                    {
                        MessageBox.Show("Укажите корректный порт назначения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    var destinationPort = Ports.FirstOrDefault(port => port.Name == shipment.DestinationPort.Name);
                    if (destinationPort != null)
                    {
                        shipment.DestinationPortId = destinationPort.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Не найден указанный порт назначения: {shipment.DestinationPort.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    if (!shipment.VoyageId.HasValue)
                    {
                        MessageBox.Show("Введите номер рейса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    
                    if (_voyageCrud.ReadById(shipment.VoyageId.Value) == null)
                    {
                        MessageBox.Show($"Введённый номер рейса не найден: {shipment.VoyageId.Value}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
        
                    try
                    {
                        try
                        {
                            Shipment ShipmentForAdd = new Shipment(
                                shipment.SendingCompanyId, 
                                shipment.ReceivingCompanyId,
                                shipment.VoyageId, 
                                shipment.DestinationPortId, 
                                shipment.SourcePortId,
                                shipment.CustomsBatchNumber, 
                                shipment.CustomsDeclarationNumber, 
                                shipment.DepartureDate,
                                shipment.ArrivalDate
                            );
                            _shipmentCrud.Create(ShipmentForAdd);
                            ShipmentForClient = _shipmentCrud.ReadByCompanyIds(EditingClient.Id);
                            OnPropertyChanged(nameof(ShipmentForClient));
                            MessageBox.Show("Партия груза добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Произошла ошибка при добавлении партии груза: {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            Console.WriteLine($"Ошибка при добавлении партии груза: {e}");
                        }
        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Произошла ошибка при добавлении партии груза: {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine($"Ошибка при добавлении партии груза: {e}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Критическая ошибка: {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine($"Критическая ошибка: {e}");
        }
    }

    private bool CompareShipments(Shipment original, Shipment updated)
    {
        return original.SendingCompanyId != updated.SendingCompanyId ||
               original.ReceivingCompanyId != updated.ReceivingCompanyId ||
               original.VoyageId != updated.VoyageId ||
               original.SourcePortId != updated.SourcePortId ||
               original.DestinationPortId != updated.DestinationPortId ||
               original.CustomsBatchNumber != updated.CustomsBatchNumber ||
               original.CustomsDeclarationNumber != updated.CustomsDeclarationNumber ||
               original.DepartureDate != updated.DepartureDate ||
               original.ArrivalDate != updated.ArrivalDate;
    }
    
    private void UpdateShipmentReferences(Shipment shipment)
    {
        // Присваиваем идентификаторы для SendingCompany
        if (shipment.SendingCompany != null && !string.IsNullOrWhiteSpace(shipment.SendingCompany.Name))
        {
            var sendingCompany = _clientCompanyCrud.ReadByCompanyName(shipment.SendingCompany.Name);
            if (sendingCompany != null)
            {
                shipment.SendingCompanyId = sendingCompany.Id;
            }
        }

        // Присваиваем идентификаторы для ReceivingCompany
        if (shipment.ReceivingCompany != null && !string.IsNullOrWhiteSpace(shipment.ReceivingCompany.Name))
        {
            var receivingCompany = _clientCompanyCrud.ReadByCompanyName(shipment.ReceivingCompany.Name);
            if (receivingCompany != null)
            {
                shipment.ReceivingCompanyId = receivingCompany.Id;
            }
        }

        // Присваиваем идентификаторы для SourcePort
        if (shipment.SourcePort != null && !string.IsNullOrWhiteSpace(shipment.SourcePort.Name))
        {
            var sourcePort = Ports.FirstOrDefault(port => port.Name == shipment.SourcePort.Name);
            if (sourcePort != null)
            {
                shipment.SourcePortId = sourcePort.Id;
            }
        }

        // Присваиваем идентификаторы для DestinationPort
        if (shipment.DestinationPort != null && !string.IsNullOrWhiteSpace(shipment.DestinationPort.Name))
        {
            var destinationPort = Ports.FirstOrDefault(port => port.Name == shipment.DestinationPort.Name);
            if (destinationPort != null)
            {
                shipment.DestinationPortId = destinationPort.Id;
            }
        }
    }

    private void SaveChangesShipmentCommand(object parameter)
    {
        try
        {
            if (ShipmentForClient == null || ShipmentForClient.Count == 0)
            {
                MessageBox.Show("Список партий груза пуст или не инициализирован.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (Shipment shipment in ShipmentForClient)
            {
                if (shipment == null)
                {
                    MessageBox.Show("Обнаружена пустая запись в списке партий груза.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    continue;
                }

                if (shipment.Id != 0) // Проверяем только существующие записи
                {
                    bool hasChange = false;
                    // Получаем оригинальную запись из базы данных
                    var originalShipment = _shipmentCrud.ReadById(shipment.Id);

                    if (originalShipment == null)
                    {
                        MessageBox.Show($"Не найдена партия груза с ID {shipment.Id} в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        continue;
                    }
                    // Проверка VoyageId
                    if (shipment.VoyageId != originalShipment.VoyageId)
                    {
                        Voyage voyage = _voyageCrud.ReadById(shipment.VoyageId.Value);
                        if (voyage == null)
                        {
                            MessageBox.Show(
                                $"Для партии груза под номером {shipment.Id} найдено рейса под указанным номером");
                            return;
                        }

                        hasChange = true;
                    }

                    if (shipment.DepartureDate != originalShipment.DepartureDate) hasChange = true;
                    if (shipment.ArrivalDate != originalShipment.ArrivalDate) hasChange = true; 
                    if (shipment.SendingCompany != originalShipment.SendingCompany) hasChange = true;
                    if (shipment.ReceivingCompany != originalShipment.ReceivingCompany) hasChange = true;
                    if (shipment.SourcePort != originalShipment.SourcePort) hasChange = true;
                    if (shipment.DestinationPort != originalShipment.DestinationPort) hasChange = true;
                    if(shipment.CustomsBatchNumber != originalShipment)
                    
                    
                    if (!shipment.VoyageId.HasValue || _voyageCrud.ReadById(shipment.VoyageId.Value) == null)
                    {
                        MessageBox.Show($"Для партии груза с ID {shipment.Id} не найден рейс с указанным номером.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    // Проверяем изменения
                    bool hasChanges = CompareShipments(originalShipment, shipment);

                    if (!hasChanges)
                    {
                        // Если изменений нет, пропускаем сохранение
                        Console.WriteLine($"Изменений для партии груза с ID {shipment.Id} не найдено.");
                        continue;
                    }
                    
                    // Присваиваем идентификаторы для портов и компаний
                    UpdateShipmentReferences(shipment);

                    try
                    {
                        // Сохраняем изменения
                        _shipmentCrud.Update(shipment);
                        Console.WriteLine($"Изменения для партии груза с ID {shipment.Id} сохранены.");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Ошибка при сохранении изменений для партии груза с ID {shipment.Id}: {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        Console.WriteLine($"Ошибка при сохранении изменений для партии груза с ID {shipment.Id}: {e}");
                    }
                }
            }

            MessageBox.Show("Все изменения сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Критическая ошибка: {e.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine($"Критическая ошибка: {e}");
        }
    }

    

    private void DeleteShipmentCommand(object parameter)
    {
        
    }
    private void CreateCargoCommand(object parameter)
    {
        
    }
    private void SaveChangesCargoCommand(object parameter)
    {
        
    }
    private void DeleteCargoCommand(object parameter)
    {
        
    }
}