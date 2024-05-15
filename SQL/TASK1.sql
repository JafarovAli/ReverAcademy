/*Create table Products (
	Id int Primary Key Identity(1,1),
	Name nvarchar(20),
	Category nvarchar(20),
	Price float
)
Create table Orders (
	Id int Primary Key Identity(1,1),
	Customer_Id int,
	Product_Id int FOREIGN KEY REFERENCES Products(Id),
	Order_Date date,
	Quantity int
)*/

-- 1.  Müəyyən bir müştərinin (məsələn, customer_id = 1) sifariş etdiyi məhsulların adlarını tapın:
Select Name from Products

-- 2. Bir kateqoriyada (məsələn, "Electronics") olan bütün məhsulların ümumi sifariş miqdarını tapın:
Select Quantity from Orders

--3. Bütün məhsulların maksimum sifariş miqdarını tapın:
Select MAX(Quantity) as MaximumQuantity from Orders

--4. Sifarişlərdə ən çox təkrar edilən məhsul ID-sini tapın:
SELECT TOP 1 Product_Id, COUNT(*) AS TotalOrders
FROM Orders
GROUP BY Product_Id
ORDER BY TotalOrders Desc

--5. Bütün məhsulların orta qiymətini tapın:
Select AVG(Price) AS AveragePrice from Products

--6. Ən bahalı məhsulun adını və qiymətini tapın:
Select Top 1 Name,Price from Products
Order by Price DESC

--7. Məhsulun (məsələn, product_id = 1) orta sifariş miqdarını tapın:

Select AVG(Quantity) as AverageQuantity from Orders
Where Product_Id = 1