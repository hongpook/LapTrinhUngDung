
namespace Project
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="VehicleShowroomManagementSystem")]
	public partial class DbContextDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAssigning(Assigning instance);
    partial void UpdateAssigning(Assigning instance);
    partial void DeleteAssigning(Assigning instance);
    partial void InsertCar(Car instance);
    partial void UpdateCar(Car instance);
    partial void DeleteCar(Car instance);
    partial void InsertCarModel(CarModel instance);
    partial void UpdateCarModel(CarModel instance);
    partial void DeleteCarModel(CarModel instance);
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertDepartment(Department instance);
    partial void UpdateDepartment(Department instance);
    partial void DeleteDepartment(Department instance);
    partial void InsertEmployee(Employee instance);
    partial void UpdateEmployee(Employee instance);
    partial void DeleteEmployee(Employee instance);
    partial void InsertManufactory(Manufactory instance);
    partial void UpdateManufactory(Manufactory instance);
    partial void DeleteManufactory(Manufactory instance);
    partial void InsertOrder(Order instance);
    partial void UpdateOrder(Order instance);
    partial void DeleteOrder(Order instance);
    partial void InsertOrderDetail(OrderDetail instance);
    partial void UpdateOrderDetail(OrderDetail instance);
    partial void DeleteOrderDetail(OrderDetail instance);
    partial void InsertPurchaseOrder(PurchaseOrder instance);
    partial void UpdatePurchaseOrder(PurchaseOrder instance);
    partial void DeletePurchaseOrder(PurchaseOrder instance);
    partial void InsertPurchaseOrderDetail(PurchaseOrderDetail instance);
    partial void UpdatePurchaseOrderDetail(PurchaseOrderDetail instance);
    partial void DeletePurchaseOrderDetail(PurchaseOrderDetail instance);
    partial void InsertService(Service instance);
    partial void UpdateService(Service instance);
    partial void DeleteService(Service instance);
    partial void InsertServiceDetail(ServiceDetail instance);
    partial void UpdateServiceDetail(ServiceDetail instance);
    partial void DeleteServiceDetail(ServiceDetail instance);
    #endregion
		
		public DbContextDataContext() : 
				base(global::Project.Properties.Settings.Default.VehicleShowroomManagementSystemConnectionString5, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DbContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Assigning> Assignings
		{
			get
			{
				return this.GetTable<Assigning>();
			}
		}
		
		public System.Data.Linq.Table<Car> Cars
		{
			get
			{
				return this.GetTable<Car>();
			}
		}
		
		public System.Data.Linq.Table<CarModel> CarModels
		{
			get
			{
				return this.GetTable<CarModel>();
			}
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<Department> Departments
		{
			get
			{
				return this.GetTable<Department>();
			}
		}
		
		public System.Data.Linq.Table<Employee> Employees
		{
			get
			{
				return this.GetTable<Employee>();
			}
		}
		
		public System.Data.Linq.Table<Manufactory> Manufactories
		{
			get
			{
				return this.GetTable<Manufactory>();
			}
		}
		
		public System.Data.Linq.Table<Order> Orders
		{
			get
			{
				return this.GetTable<Order>();
			}
		}
		
		public System.Data.Linq.Table<OrderDetail> OrderDetails
		{
			get
			{
				return this.GetTable<OrderDetail>();
			}
		}
		
		public System.Data.Linq.Table<PurchaseOrder> PurchaseOrders
		{
			get
			{
				return this.GetTable<PurchaseOrder>();
			}
		}
		
		public System.Data.Linq.Table<PurchaseOrderDetail> PurchaseOrderDetails
		{
			get
			{
				return this.GetTable<PurchaseOrderDetail>();
			}
		}
		
		public System.Data.Linq.Table<Service> Services
		{
			get
			{
				return this.GetTable<Service>();
			}
		}
		
		public System.Data.Linq.Table<ServiceDetail> ServiceDetails
		{
			get
			{
				return this.GetTable<ServiceDetail>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.totalCar")]
		public int totalCar([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.quantityNhap")]
		public ISingleResult<quantityNhapResult> quantityNhap([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> start, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> end)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), start, end);
			return ((ISingleResult<quantityNhapResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Assigning")]
	public partial class Assigning : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _OrderID;
		
		private System.DateTime _OnAssigning;
		
		private long _EmployeeID;
		
		private long _AssigningID;
		
		private EntityRef<Employee> _Employee;
		
		private EntityRef<Order> _Order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIDChanging(long value);
    partial void OnOrderIDChanged();
    partial void OnOnAssigningChanging(System.DateTime value);
    partial void OnOnAssigningChanged();
    partial void OnEmployeeIDChanging(long value);
    partial void OnEmployeeIDChanged();
    partial void OnAssigningIDChanging(long value);
    partial void OnAssigningIDChanged();
    #endregion
		
		public Assigning()
		{
			this._Employee = default(EntityRef<Employee>);
			this._Order = default(EntityRef<Order>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", DbType="BigInt NOT NULL")]
		public long OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOrderIDChanging(value);
					this.SendPropertyChanging();
					this._OrderID = value;
					this.SendPropertyChanged("OrderID");
					this.OnOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OnAssigning", DbType="Date NOT NULL")]
		public System.DateTime OnAssigning
		{
			get
			{
				return this._OnAssigning;
			}
			set
			{
				if ((this._OnAssigning != value))
				{
					this.OnOnAssigningChanging(value);
					this.SendPropertyChanging();
					this._OnAssigning = value;
					this.SendPropertyChanged("OnAssigning");
					this.OnOnAssigningChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeID", DbType="BigInt NOT NULL")]
		public long EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if ((this._EmployeeID != value))
				{
					if (this._Employee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIDChanging(value);
					this.SendPropertyChanging();
					this._EmployeeID = value;
					this.SendPropertyChanged("EmployeeID");
					this.OnEmployeeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AssigningID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long AssigningID
		{
			get
			{
				return this._AssigningID;
			}
			set
			{
				if ((this._AssigningID != value))
				{
					this.OnAssigningIDChanging(value);
					this.SendPropertyChanging();
					this._AssigningID = value;
					this.SendPropertyChanged("AssigningID");
					this.OnAssigningIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Assigning", Storage="_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee Employee
		{
			get
			{
				return this._Employee.Entity;
			}
			set
			{
				Employee previousValue = this._Employee.Entity;
				if (((previousValue != value) 
							|| (this._Employee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee.Entity = null;
						previousValue.Assignings.Remove(this);
					}
					this._Employee.Entity = value;
					if ((value != null))
					{
						value.Assignings.Add(this);
						this._EmployeeID = value.EmployeeID;
					}
					else
					{
						this._EmployeeID = default(long);
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Assigning", Storage="_Order", ThisKey="OrderID", OtherKey="OrderID", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.Assignings.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.Assignings.Add(this);
						this._OrderID = value.OrderID;
					}
					else
					{
						this._OrderID = default(long);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Car")]
	public partial class Car : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _CarNo;
		
		private string _ModelName;
		
		private string _Name;
		
		private double _Price;
		
		private bool _Status;
		
		private string _AddInfor;
		
		private EntitySet<OrderDetail> _OrderDetails;
		
		private EntitySet<PurchaseOrderDetail> _PurchaseOrderDetails;
		
		private EntitySet<ServiceDetail> _ServiceDetails;
		
		private EntityRef<CarModel> _CarModel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCarNoChanging(long value);
    partial void OnCarNoChanged();
    partial void OnModelNameChanging(string value);
    partial void OnModelNameChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPriceChanging(double value);
    partial void OnPriceChanged();
    partial void OnStatusChanging(System.Nullable<bool> value);
    partial void OnStatusChanged();
    partial void OnAddInforChanging(string value);
    partial void OnAddInforChanged();
    #endregion
		
		public Car()
		{
			this._OrderDetails = new EntitySet<OrderDetail>(new Action<OrderDetail>(this.attach_OrderDetails), new Action<OrderDetail>(this.detach_OrderDetails));
			this._PurchaseOrderDetails = new EntitySet<PurchaseOrderDetail>(new Action<PurchaseOrderDetail>(this.attach_PurchaseOrderDetails), new Action<PurchaseOrderDetail>(this.detach_PurchaseOrderDetails));
			this._ServiceDetails = new EntitySet<ServiceDetail>(new Action<ServiceDetail>(this.attach_ServiceDetails), new Action<ServiceDetail>(this.detach_ServiceDetails));
			this._CarModel = default(EntityRef<CarModel>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarNo", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long CarNo
		{
			get
			{
				return this._CarNo;
			}
			set
			{
				if ((this._CarNo != value))
				{
					this.OnCarNoChanging(value);
					this.SendPropertyChanging();
					this._CarNo = value;
					this.SendPropertyChanged("CarNo");
					this.OnCarNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModelName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ModelName
		{
			get
			{
				return this._ModelName;
			}
			set
			{
				if ((this._ModelName != value))
				{
					if (this._CarModel.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnModelNameChanging(value);
					this.SendPropertyChanging();
					this._ModelName = value;
					this.SendPropertyChanged("ModelName");
					this.OnModelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float NOT NULL")]
		public double Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddInfor", DbType="NVarChar(100)")]
		public string AddInfor
		{
			get
			{
				return this._AddInfor;
			}
			set
			{
				if ((this._AddInfor != value))
				{
					this.OnAddInforChanging(value);
					this.SendPropertyChanging();
					this._AddInfor = value;
					this.SendPropertyChanged("AddInfor");
					this.OnAddInforChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_OrderDetail", Storage="_OrderDetails", ThisKey="CarNo", OtherKey="CarNo")]
		public EntitySet<OrderDetail> OrderDetails
		{
			get
			{
				return this._OrderDetails;
			}
			set
			{
				this._OrderDetails.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_PurchaseOrderDetail", Storage="_PurchaseOrderDetails", ThisKey="CarNo", OtherKey="CarNo")]
		public EntitySet<PurchaseOrderDetail> PurchaseOrderDetails
		{
			get
			{
				return this._PurchaseOrderDetails;
			}
			set
			{
				this._PurchaseOrderDetails.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_ServiceDetail", Storage="_ServiceDetails", ThisKey="CarNo", OtherKey="CarNo")]
		public EntitySet<ServiceDetail> ServiceDetails
		{
			get
			{
				return this._ServiceDetails;
			}
			set
			{
				this._ServiceDetails.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CarModel_Car", Storage="_CarModel", ThisKey="ModelName", OtherKey="ModelName", IsForeignKey=true)]
		public CarModel CarModel
		{
			get
			{
				return this._CarModel.Entity;
			}
			set
			{
				CarModel previousValue = this._CarModel.Entity;
				if (((previousValue != value) 
							|| (this._CarModel.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CarModel.Entity = null;
						previousValue.Cars.Remove(this);
					}
					this._CarModel.Entity = value;
					if ((value != null))
					{
						value.Cars.Add(this);
						this._ModelName = value.ModelName;
					}
					else
					{
						this._ModelName = default(string);
					}
					this.SendPropertyChanged("CarModel");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_OrderDetails(OrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = this;
		}
		
		private void detach_OrderDetails(OrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = null;
		}
		
		private void attach_PurchaseOrderDetails(PurchaseOrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = this;
		}
		
		private void detach_PurchaseOrderDetails(PurchaseOrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = null;
		}
		
		private void attach_ServiceDetails(ServiceDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = this;
		}
		
		private void detach_ServiceDetails(ServiceDetail entity)
		{
			this.SendPropertyChanging();
			entity.Car = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CarModel")]
	public partial class CarModel : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ModelName;
		
		private string _AddInfor;
		
		private int _ManufactoryID;
		
		private System.Data.Linq.Binary _Image;
		
		private EntitySet<Car> _Cars;
		
		private EntityRef<Manufactory> _Manufactory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnModelNameChanging(string value);
    partial void OnModelNameChanged();
    partial void OnAddInforChanging(string value);
    partial void OnAddInforChanged();
    partial void OnManufactoryIDChanging(int value);
    partial void OnManufactoryIDChanged();
    partial void OnImageChanging(System.Data.Linq.Binary value);
    partial void OnImageChanged();
    #endregion
		
		public CarModel()
		{
			this._Cars = new EntitySet<Car>(new Action<Car>(this.attach_Cars), new Action<Car>(this.detach_Cars));
			this._Manufactory = default(EntityRef<Manufactory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModelName", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ModelName
		{
			get
			{
				return this._ModelName;
			}
			set
			{
				if ((this._ModelName != value))
				{
					this.OnModelNameChanging(value);
					this.SendPropertyChanging();
					this._ModelName = value;
					this.SendPropertyChanged("ModelName");
					this.OnModelNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddInfor", DbType="NVarChar(100)")]
		public string AddInfor
		{
			get
			{
				return this._AddInfor;
			}
			set
			{
				if ((this._AddInfor != value))
				{
					this.OnAddInforChanging(value);
					this.SendPropertyChanging();
					this._AddInfor = value;
					this.SendPropertyChanged("AddInfor");
					this.OnAddInforChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManufactoryID", DbType="Int NOT NULL")]
		public int ManufactoryID
		{
			get
			{
				return this._ManufactoryID;
			}
			set
			{
				if ((this._ManufactoryID != value))
				{
					if (this._Manufactory.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnManufactoryIDChanging(value);
					this.SendPropertyChanging();
					this._ManufactoryID = value;
					this.SendPropertyChanged("ManufactoryID");
					this.OnManufactoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Image", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if ((this._Image != value))
				{
					this.OnImageChanging(value);
					this.SendPropertyChanging();
					this._Image = value;
					this.SendPropertyChanged("Image");
					this.OnImageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CarModel_Car", Storage="_Cars", ThisKey="ModelName", OtherKey="ModelName")]
		public EntitySet<Car> Cars
		{
			get
			{
				return this._Cars;
			}
			set
			{
				this._Cars.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Manufactory_CarModel", Storage="_Manufactory", ThisKey="ManufactoryID", OtherKey="ManufactoryID", IsForeignKey=true)]
		public Manufactory Manufactory
		{
			get
			{
				return this._Manufactory.Entity;
			}
			set
			{
				Manufactory previousValue = this._Manufactory.Entity;
				if (((previousValue != value) 
							|| (this._Manufactory.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Manufactory.Entity = null;
						previousValue.CarModels.Remove(this);
					}
					this._Manufactory.Entity = value;
					if ((value != null))
					{
						value.CarModels.Add(this);
						this._ManufactoryID = value.ManufactoryID;
					}
					else
					{
						this._ManufactoryID = default(int);
					}
					this.SendPropertyChanged("Manufactory");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.CarModel = this;
		}
		
		private void detach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.CarModel = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _CustomerID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private bool _Sex;
		
		private System.DateTime _DateOfBirth;
		
		private string _Address;
		
		private int _Phone;
		
		private EntitySet<Order> _Orders;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustomerIDChanging(long value);
    partial void OnCustomerIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSexChanging(bool value);
    partial void OnSexChanged();
    partial void OnDateOfBirthChanging(System.DateTime value);
    partial void OnDateOfBirthChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneChanging(int value);
    partial void OnPhoneChanged();
    #endregion
		
		public Customer()
		{
			this._Orders = new EntitySet<Order>(new Action<Order>(this.attach_Orders), new Action<Order>(this.detach_Orders));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Bit NOT NULL")]
		public bool Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfBirth", DbType="Date NOT NULL")]
		public System.DateTime DateOfBirth
		{
			get
			{
				return this._DateOfBirth;
			}
			set
			{
				if ((this._DateOfBirth != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DateOfBirth = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="Int NOT NULL")]
		public int Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Order", Storage="_Orders", ThisKey="CustomerID", OtherKey="CustomerID")]
		public EntitySet<Order> Orders
		{
			get
			{
				return this._Orders;
			}
			set
			{
				this._Orders.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.Customer = this;
		}
		
		private void detach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.Customer = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Department")]
	public partial class Department : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _DepartmentName;
		
		private EntitySet<Employee> _Employees;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDepartmentNameChanging(string value);
    partial void OnDepartmentNameChanged();
    #endregion
		
		public Department()
		{
			this._Employees = new EntitySet<Employee>(new Action<Employee>(this.attach_Employees), new Action<Employee>(this.detach_Employees));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartmentName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string DepartmentName
		{
			get
			{
				return this._DepartmentName;
			}
			set
			{
				if ((this._DepartmentName != value))
				{
					this.OnDepartmentNameChanging(value);
					this.SendPropertyChanging();
					this._DepartmentName = value;
					this.SendPropertyChanged("DepartmentName");
					this.OnDepartmentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Department_Employee", Storage="_Employees", ThisKey="DepartmentName", OtherKey="DepartmentName")]
		public EntitySet<Employee> Employees
		{
			get
			{
				return this._Employees;
			}
			set
			{
				this._Employees.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Department = this;
		}
		
		private void detach_Employees(Employee entity)
		{
			this.SendPropertyChanging();
			entity.Department = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Employee")]
	public partial class Employee : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _EmployeeID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private bool _Sex;
		
		private System.DateTime _DateOfBirth;
		
		private string _Address;
		
		private int _Phone;
		
		private string _DepartmentName;
		
		private string _UserName;
		
		private string _Password;
		
		private System.Data.Linq.Binary _Photo;
		
		private EntitySet<Assigning> _Assignings;
		
		private EntitySet<Order> _Orders;
		
		private EntitySet<PurchaseOrder> _PurchaseOrders;
		
		private EntityRef<Department> _Department;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmployeeIDChanging(long value);
    partial void OnEmployeeIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSexChanging(bool value);
    partial void OnSexChanged();
    partial void OnDateOfBirthChanging(System.DateTime value);
    partial void OnDateOfBirthChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneChanging(int value);
    partial void OnPhoneChanged();
    partial void OnDepartmentNameChanging(string value);
    partial void OnDepartmentNameChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnPhotoChanging(System.Data.Linq.Binary value);
    partial void OnPhotoChanged();
    #endregion
		
		public Employee()
		{
			this._Assignings = new EntitySet<Assigning>(new Action<Assigning>(this.attach_Assignings), new Action<Assigning>(this.detach_Assignings));
			this._Orders = new EntitySet<Order>(new Action<Order>(this.attach_Orders), new Action<Order>(this.detach_Orders));
			this._PurchaseOrders = new EntitySet<PurchaseOrder>(new Action<PurchaseOrder>(this.attach_PurchaseOrders), new Action<PurchaseOrder>(this.detach_PurchaseOrders));
			this._Department = default(EntityRef<Department>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if ((this._EmployeeID != value))
				{
					this.OnEmployeeIDChanging(value);
					this.SendPropertyChanging();
					this._EmployeeID = value;
					this.SendPropertyChanged("EmployeeID");
					this.OnEmployeeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="Bit NOT NULL")]
		public bool Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfBirth", DbType="Date NOT NULL")]
		public System.DateTime DateOfBirth
		{
			get
			{
				return this._DateOfBirth;
			}
			set
			{
				if ((this._DateOfBirth != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DateOfBirth = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="Int NOT NULL")]
		public int Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartmentName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string DepartmentName
		{
			get
			{
				return this._DepartmentName;
			}
			set
			{
				if ((this._DepartmentName != value))
				{
					if (this._Department.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDepartmentNameChanging(value);
					this.SendPropertyChanging();
					this._DepartmentName = value;
					this.SendPropertyChanged("DepartmentName");
					this.OnDepartmentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(20)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(20)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Photo", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Photo
		{
			get
			{
				return this._Photo;
			}
			set
			{
				if ((this._Photo != value))
				{
					this.OnPhotoChanging(value);
					this.SendPropertyChanging();
					this._Photo = value;
					this.SendPropertyChanged("Photo");
					this.OnPhotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Assigning", Storage="_Assignings", ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<Assigning> Assignings
		{
			get
			{
				return this._Assignings;
			}
			set
			{
				this._Assignings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Order", Storage="_Orders", ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<Order> Orders
		{
			get
			{
				return this._Orders;
			}
			set
			{
				this._Orders.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_PurchaseOrder", Storage="_PurchaseOrders", ThisKey="EmployeeID", OtherKey="EmployeeID")]
		public EntitySet<PurchaseOrder> PurchaseOrders
		{
			get
			{
				return this._PurchaseOrders;
			}
			set
			{
				this._PurchaseOrders.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Department_Employee", Storage="_Department", ThisKey="DepartmentName", OtherKey="DepartmentName", IsForeignKey=true)]
		public Department Department
		{
			get
			{
				return this._Department.Entity;
			}
			set
			{
				Department previousValue = this._Department.Entity;
				if (((previousValue != value) 
							|| (this._Department.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Department.Entity = null;
						previousValue.Employees.Remove(this);
					}
					this._Department.Entity = value;
					if ((value != null))
					{
						value.Employees.Add(this);
						this._DepartmentName = value.DepartmentName;
					}
					else
					{
						this._DepartmentName = default(string);
					}
					this.SendPropertyChanged("Department");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Assignings(Assigning entity)
		{
			this.SendPropertyChanging();
			entity.Employee = this;
		}
		
		private void detach_Assignings(Assigning entity)
		{
			this.SendPropertyChanging();
			entity.Employee = null;
		}
		
		private void attach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.Employee = this;
		}
		
		private void detach_Orders(Order entity)
		{
			this.SendPropertyChanging();
			entity.Employee = null;
		}
		
		private void attach_PurchaseOrders(PurchaseOrder entity)
		{
			this.SendPropertyChanging();
			entity.Employee = this;
		}
		
		private void detach_PurchaseOrders(PurchaseOrder entity)
		{
			this.SendPropertyChanging();
			entity.Employee = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Manufactory")]
	public partial class Manufactory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ManufactoryID;
		
		private string _ManufactoryName;
		
		private string _Address;
		
		private int _Phone;
		
		private string _AddInfor;
		
		private System.Data.Linq.Binary _Logo;
		
		private EntitySet<CarModel> _CarModels;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnManufactoryIDChanging(int value);
    partial void OnManufactoryIDChanged();
    partial void OnManufactoryNameChanging(string value);
    partial void OnManufactoryNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnPhoneChanging(int value);
    partial void OnPhoneChanged();
    partial void OnAddInforChanging(string value);
    partial void OnAddInforChanged();
    partial void OnLogoChanging(System.Data.Linq.Binary value);
    partial void OnLogoChanged();
    #endregion
		
		public Manufactory()
		{
			this._CarModels = new EntitySet<CarModel>(new Action<CarModel>(this.attach_CarModels), new Action<CarModel>(this.detach_CarModels));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManufactoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ManufactoryID
		{
			get
			{
				return this._ManufactoryID;
			}
			set
			{
				if ((this._ManufactoryID != value))
				{
					this.OnManufactoryIDChanging(value);
					this.SendPropertyChanging();
					this._ManufactoryID = value;
					this.SendPropertyChanged("ManufactoryID");
					this.OnManufactoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManufactoryName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ManufactoryName
		{
			get
			{
				return this._ManufactoryName;
			}
			set
			{
				if ((this._ManufactoryName != value))
				{
					this.OnManufactoryNameChanging(value);
					this.SendPropertyChanging();
					this._ManufactoryName = value;
					this.SendPropertyChanged("ManufactoryName");
					this.OnManufactoryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="Int NOT NULL")]
		public int Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddInfor", DbType="NVarChar(100)")]
		public string AddInfor
		{
			get
			{
				return this._AddInfor;
			}
			set
			{
				if ((this._AddInfor != value))
				{
					this.OnAddInforChanging(value);
					this.SendPropertyChanging();
					this._AddInfor = value;
					this.SendPropertyChanged("AddInfor");
					this.OnAddInforChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logo", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Logo
		{
			get
			{
				return this._Logo;
			}
			set
			{
				if ((this._Logo != value))
				{
					this.OnLogoChanging(value);
					this.SendPropertyChanging();
					this._Logo = value;
					this.SendPropertyChanged("Logo");
					this.OnLogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Manufactory_CarModel", Storage="_CarModels", ThisKey="ManufactoryID", OtherKey="ManufactoryID")]
		public EntitySet<CarModel> CarModels
		{
			get
			{
				return this._CarModels;
			}
			set
			{
				this._CarModels.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CarModels(CarModel entity)
		{
			this.SendPropertyChanging();
			entity.Manufactory = this;
		}
		
		private void detach_CarModels(CarModel entity)
		{
			this.SendPropertyChanging();
			entity.Manufactory = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Order]")]
	public partial class Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _OrderID;
		
		private long _CustomerID;
		
		private System.DateTime _OnOrder;
		
		private long _EmployeeID;
		
		private string _Request;
		
		private bool _Confirmation;
		
		private EntitySet<Assigning> _Assignings;
		
		private EntitySet<OrderDetail> _OrderDetails;
		
		private EntityRef<Customer> _Customer;
		
		private EntityRef<Employee> _Employee;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIDChanging(long value);
    partial void OnOrderIDChanged();
    partial void OnCustomerIDChanging(long value);
    partial void OnCustomerIDChanged();
    partial void OnOnOrderChanging(System.DateTime value);
    partial void OnOnOrderChanged();
    partial void OnEmployeeIDChanging(long value);
    partial void OnEmployeeIDChanged();
    partial void OnRequestChanging(string value);
    partial void OnRequestChanged();
    partial void OnConfirmationChanging(bool value);
    partial void OnConfirmationChanged();
    #endregion
		
		public Order()
		{
			this._Assignings = new EntitySet<Assigning>(new Action<Assigning>(this.attach_Assignings), new Action<Assigning>(this.detach_Assignings));
			this._OrderDetails = new EntitySet<OrderDetail>(new Action<OrderDetail>(this.attach_OrderDetails), new Action<OrderDetail>(this.detach_OrderDetails));
			this._Customer = default(EntityRef<Customer>);
			this._Employee = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					this.OnOrderIDChanging(value);
					this.SendPropertyChanging();
					this._OrderID = value;
					this.SendPropertyChanged("OrderID");
					this.OnOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="BigInt NOT NULL")]
		public long CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					if (this._Customer.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OnOrder", DbType="Date NOT NULL")]
		public System.DateTime OnOrder
		{
			get
			{
				return this._OnOrder;
			}
			set
			{
				if ((this._OnOrder != value))
				{
					this.OnOnOrderChanging(value);
					this.SendPropertyChanging();
					this._OnOrder = value;
					this.SendPropertyChanged("OnOrder");
					this.OnOnOrderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeID", DbType="BigInt NOT NULL")]
		public long EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if ((this._EmployeeID != value))
				{
					if (this._Employee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIDChanging(value);
					this.SendPropertyChanging();
					this._EmployeeID = value;
					this.SendPropertyChanged("EmployeeID");
					this.OnEmployeeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Request", DbType="NVarChar(100)")]
		public string Request
		{
			get
			{
				return this._Request;
			}
			set
			{
				if ((this._Request != value))
				{
					this.OnRequestChanging(value);
					this.SendPropertyChanging();
					this._Request = value;
					this.SendPropertyChanged("Request");
					this.OnRequestChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Confirmation", DbType="Bit NOT NULL")]
		public bool Confirmation
		{
			get
			{
				return this._Confirmation;
			}
			set
			{
				if ((this._Confirmation != value))
				{
					this.OnConfirmationChanging(value);
					this.SendPropertyChanging();
					this._Confirmation = value;
					this.SendPropertyChanged("Confirmation");
					this.OnConfirmationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_Assigning", Storage="_Assignings", ThisKey="OrderID", OtherKey="OrderID")]
		public EntitySet<Assigning> Assignings
		{
			get
			{
				return this._Assignings;
			}
			set
			{
				this._Assignings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_OrderDetail", Storage="_OrderDetails", ThisKey="OrderID", OtherKey="OrderID")]
		public EntitySet<OrderDetail> OrderDetails
		{
			get
			{
				return this._OrderDetails;
			}
			set
			{
				this._OrderDetails.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Customer_Order", Storage="_Customer", ThisKey="CustomerID", OtherKey="CustomerID", IsForeignKey=true)]
		public Customer Customer
		{
			get
			{
				return this._Customer.Entity;
			}
			set
			{
				Customer previousValue = this._Customer.Entity;
				if (((previousValue != value) 
							|| (this._Customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer.Entity = null;
						previousValue.Orders.Remove(this);
					}
					this._Customer.Entity = value;
					if ((value != null))
					{
						value.Orders.Add(this);
						this._CustomerID = value.CustomerID;
					}
					else
					{
						this._CustomerID = default(long);
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_Order", Storage="_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee Employee
		{
			get
			{
				return this._Employee.Entity;
			}
			set
			{
				Employee previousValue = this._Employee.Entity;
				if (((previousValue != value) 
							|| (this._Employee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee.Entity = null;
						previousValue.Orders.Remove(this);
					}
					this._Employee.Entity = value;
					if ((value != null))
					{
						value.Orders.Add(this);
						this._EmployeeID = value.EmployeeID;
					}
					else
					{
						this._EmployeeID = default(long);
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Assignings(Assigning entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_Assignings(Assigning entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
		
		private void attach_OrderDetails(OrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Order = this;
		}
		
		private void detach_OrderDetails(OrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.Order = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OrderDetails")]
	public partial class OrderDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _OrderID;
		
		private long _CarNo;
		
		private int _Quantity;
		
		private EntityRef<Car> _Car;
		
		private EntityRef<Order> _Order;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOrderIDChanging(long value);
    partial void OnOrderIDChanged();
    partial void OnCarNoChanging(long value);
    partial void OnCarNoChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public OrderDetail()
		{
			this._Car = default(EntityRef<Car>);
			this._Order = default(EntityRef<Order>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long OrderID
		{
			get
			{
				return this._OrderID;
			}
			set
			{
				if ((this._OrderID != value))
				{
					if (this._Order.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOrderIDChanging(value);
					this.SendPropertyChanging();
					this._OrderID = value;
					this.SendPropertyChanged("OrderID");
					this.OnOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarNo", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long CarNo
		{
			get
			{
				return this._CarNo;
			}
			set
			{
				if ((this._CarNo != value))
				{
					if (this._Car.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCarNoChanging(value);
					this.SendPropertyChanging();
					this._CarNo = value;
					this.SendPropertyChanged("CarNo");
					this.OnCarNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_OrderDetail", Storage="_Car", ThisKey="CarNo", OtherKey="CarNo", IsForeignKey=true)]
		public Car Car
		{
			get
			{
				return this._Car.Entity;
			}
			set
			{
				Car previousValue = this._Car.Entity;
				if (((previousValue != value) 
							|| (this._Car.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Car.Entity = null;
						previousValue.OrderDetails.Remove(this);
					}
					this._Car.Entity = value;
					if ((value != null))
					{
						value.OrderDetails.Add(this);
						this._CarNo = value.CarNo;
					}
					else
					{
						this._CarNo = default(long);
					}
					this.SendPropertyChanged("Car");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Order_OrderDetail", Storage="_Order", ThisKey="OrderID", OtherKey="OrderID", IsForeignKey=true)]
		public Order Order
		{
			get
			{
				return this._Order.Entity;
			}
			set
			{
				Order previousValue = this._Order.Entity;
				if (((previousValue != value) 
							|| (this._Order.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Order.Entity = null;
						previousValue.OrderDetails.Remove(this);
					}
					this._Order.Entity = value;
					if ((value != null))
					{
						value.OrderDetails.Add(this);
						this._OrderID = value.OrderID;
					}
					else
					{
						this._OrderID = default(long);
					}
					this.SendPropertyChanged("Order");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PurchaseOrder")]
	public partial class PurchaseOrder : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _PurchaseOrderID;
		
		private System.DateTime _Date;
		
		private System.Nullable<long> _EmployeeID;
		
		private EntitySet<PurchaseOrderDetail> _PurchaseOrderDetails;
		
		private EntityRef<Employee> _Employee;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPurchaseOrderIDChanging(long value);
    partial void OnPurchaseOrderIDChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnEmployeeIDChanging(System.Nullable<long> value);
    partial void OnEmployeeIDChanged();
    #endregion
		
		public PurchaseOrder()
		{
			this._PurchaseOrderDetails = new EntitySet<PurchaseOrderDetail>(new Action<PurchaseOrderDetail>(this.attach_PurchaseOrderDetails), new Action<PurchaseOrderDetail>(this.detach_PurchaseOrderDetails));
			this._Employee = default(EntityRef<Employee>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PurchaseOrderID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long PurchaseOrderID
		{
			get
			{
				return this._PurchaseOrderID;
			}
			set
			{
				if ((this._PurchaseOrderID != value))
				{
					this.OnPurchaseOrderIDChanging(value);
					this.SendPropertyChanging();
					this._PurchaseOrderID = value;
					this.SendPropertyChanged("PurchaseOrderID");
					this.OnPurchaseOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeID", DbType="BigInt")]
		public System.Nullable<long> EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if ((this._EmployeeID != value))
				{
					if (this._Employee.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIDChanging(value);
					this.SendPropertyChanging();
					this._EmployeeID = value;
					this.SendPropertyChanged("EmployeeID");
					this.OnEmployeeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PurchaseOrder_PurchaseOrderDetail", Storage="_PurchaseOrderDetails", ThisKey="PurchaseOrderID", OtherKey="PurchaseOrderID")]
		public EntitySet<PurchaseOrderDetail> PurchaseOrderDetails
		{
			get
			{
				return this._PurchaseOrderDetails;
			}
			set
			{
				this._PurchaseOrderDetails.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Employee_PurchaseOrder", Storage="_Employee", ThisKey="EmployeeID", OtherKey="EmployeeID", IsForeignKey=true)]
		public Employee Employee
		{
			get
			{
				return this._Employee.Entity;
			}
			set
			{
				Employee previousValue = this._Employee.Entity;
				if (((previousValue != value) 
							|| (this._Employee.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Employee.Entity = null;
						previousValue.PurchaseOrders.Remove(this);
					}
					this._Employee.Entity = value;
					if ((value != null))
					{
						value.PurchaseOrders.Add(this);
						this._EmployeeID = value.EmployeeID;
					}
					else
					{
						this._EmployeeID = default(Nullable<long>);
					}
					this.SendPropertyChanged("Employee");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PurchaseOrderDetails(PurchaseOrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.PurchaseOrder = this;
		}
		
		private void detach_PurchaseOrderDetails(PurchaseOrderDetail entity)
		{
			this.SendPropertyChanging();
			entity.PurchaseOrder = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PurchaseOrderDetails")]
	public partial class PurchaseOrderDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _PurchaseOrderID;
		
		private long _CarNo;
		
		private int _Quantity;
		
		private double _Price;
		
		private EntityRef<Car> _Car;
		
		private EntityRef<PurchaseOrder> _PurchaseOrder;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPurchaseOrderIDChanging(long value);
    partial void OnPurchaseOrderIDChanged();
    partial void OnCarNoChanging(long value);
    partial void OnCarNoChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnPriceChanging(double value);
    partial void OnPriceChanged();
    #endregion
		
		public PurchaseOrderDetail()
		{
			this._Car = default(EntityRef<Car>);
			this._PurchaseOrder = default(EntityRef<PurchaseOrder>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PurchaseOrderID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long PurchaseOrderID
		{
			get
			{
				return this._PurchaseOrderID;
			}
			set
			{
				if ((this._PurchaseOrderID != value))
				{
					if (this._PurchaseOrder.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPurchaseOrderIDChanging(value);
					this.SendPropertyChanging();
					this._PurchaseOrderID = value;
					this.SendPropertyChanged("PurchaseOrderID");
					this.OnPurchaseOrderIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarNo", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long CarNo
		{
			get
			{
				return this._CarNo;
			}
			set
			{
				if ((this._CarNo != value))
				{
					if (this._Car.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCarNoChanging(value);
					this.SendPropertyChanging();
					this._CarNo = value;
					this.SendPropertyChanged("CarNo");
					this.OnCarNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float NOT NULL")]
		public double Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_PurchaseOrderDetail", Storage="_Car", ThisKey="CarNo", OtherKey="CarNo", IsForeignKey=true)]
		public Car Car
		{
			get
			{
				return this._Car.Entity;
			}
			set
			{
				Car previousValue = this._Car.Entity;
				if (((previousValue != value) 
							|| (this._Car.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Car.Entity = null;
						previousValue.PurchaseOrderDetails.Remove(this);
					}
					this._Car.Entity = value;
					if ((value != null))
					{
						value.PurchaseOrderDetails.Add(this);
						this._CarNo = value.CarNo;
					}
					else
					{
						this._CarNo = default(long);
					}
					this.SendPropertyChanged("Car");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PurchaseOrder_PurchaseOrderDetail", Storage="_PurchaseOrder", ThisKey="PurchaseOrderID", OtherKey="PurchaseOrderID", IsForeignKey=true)]
		public PurchaseOrder PurchaseOrder
		{
			get
			{
				return this._PurchaseOrder.Entity;
			}
			set
			{
				PurchaseOrder previousValue = this._PurchaseOrder.Entity;
				if (((previousValue != value) 
							|| (this._PurchaseOrder.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PurchaseOrder.Entity = null;
						previousValue.PurchaseOrderDetails.Remove(this);
					}
					this._PurchaseOrder.Entity = value;
					if ((value != null))
					{
						value.PurchaseOrderDetails.Add(this);
						this._PurchaseOrderID = value.PurchaseOrderID;
					}
					else
					{
						this._PurchaseOrderID = default(long);
					}
					this.SendPropertyChanged("PurchaseOrder");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Service")]
	public partial class Service : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ServiceID;
		
		private string _Name;
		
		private string _Description;
		
		private EntitySet<ServiceDetail> _ServiceDetails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnServiceIDChanging(int value);
    partial void OnServiceIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Service()
		{
			this._ServiceDetails = new EntitySet<ServiceDetail>(new Action<ServiceDetail>(this.attach_ServiceDetails), new Action<ServiceDetail>(this.detach_ServiceDetails));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ServiceID
		{
			get
			{
				return this._ServiceID;
			}
			set
			{
				if ((this._ServiceID != value))
				{
					this.OnServiceIDChanging(value);
					this.SendPropertyChanging();
					this._ServiceID = value;
					this.SendPropertyChanged("ServiceID");
					this.OnServiceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(200)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_ServiceDetail", Storage="_ServiceDetails", ThisKey="ServiceID", OtherKey="ServiceID")]
		public EntitySet<ServiceDetail> ServiceDetails
		{
			get
			{
				return this._ServiceDetails;
			}
			set
			{
				this._ServiceDetails.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ServiceDetails(ServiceDetail entity)
		{
			this.SendPropertyChanging();
			entity.Service = this;
		}
		
		private void detach_ServiceDetails(ServiceDetail entity)
		{
			this.SendPropertyChanging();
			entity.Service = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ServiceDetails")]
	public partial class ServiceDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _CarNo;
		
		private int _ServiceID;
		
		private EntityRef<Car> _Car;
		
		private EntityRef<Service> _Service;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCarNoChanging(long value);
    partial void OnCarNoChanged();
    partial void OnServiceIDChanging(int value);
    partial void OnServiceIDChanged();
    #endregion
		
		public ServiceDetail()
		{
			this._Car = default(EntityRef<Car>);
			this._Service = default(EntityRef<Service>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarNo", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long CarNo
		{
			get
			{
				return this._CarNo;
			}
			set
			{
				if ((this._CarNo != value))
				{
					if (this._Car.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCarNoChanging(value);
					this.SendPropertyChanging();
					this._CarNo = value;
					this.SendPropertyChanged("CarNo");
					this.OnCarNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ServiceID
		{
			get
			{
				return this._ServiceID;
			}
			set
			{
				if ((this._ServiceID != value))
				{
					if (this._Service.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnServiceIDChanging(value);
					this.SendPropertyChanging();
					this._ServiceID = value;
					this.SendPropertyChanged("ServiceID");
					this.OnServiceIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_ServiceDetail", Storage="_Car", ThisKey="CarNo", OtherKey="CarNo", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
		public Car Car
		{
			get
			{
				return this._Car.Entity;
			}
			set
			{
				Car previousValue = this._Car.Entity;
				if (((previousValue != value) 
							|| (this._Car.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Car.Entity = null;
						previousValue.ServiceDetails.Remove(this);
					}
					this._Car.Entity = value;
					if ((value != null))
					{
						value.ServiceDetails.Add(this);
						this._CarNo = value.CarNo;
					}
					else
					{
						this._CarNo = default(long);
					}
					this.SendPropertyChanged("Car");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Service_ServiceDetail", Storage="_Service", ThisKey="ServiceID", OtherKey="ServiceID", IsForeignKey=true)]
		public Service Service
		{
			get
			{
				return this._Service.Entity;
			}
			set
			{
				Service previousValue = this._Service.Entity;
				if (((previousValue != value) 
							|| (this._Service.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Service.Entity = null;
						previousValue.ServiceDetails.Remove(this);
					}
					this._Service.Entity = value;
					if ((value != null))
					{
						value.ServiceDetails.Add(this);
						this._ServiceID = value.ServiceID;
					}
					else
					{
						this._ServiceID = default(int);
					}
					this.SendPropertyChanged("Service");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	public partial class quantityNhapResult
	{
		
		private System.Nullable<int> _Column1;
		
		public quantityNhapResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="", Storage="_Column1", DbType="Int")]
		public System.Nullable<int> Column1
		{
			get
			{
				return this._Column1;
			}
			set
			{
				if ((this._Column1 != value))
				{
					this._Column1 = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
