
Создание таблиц - 

USE mebel;
GO

CREATE TABLE product_types (
    product_type_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL UNIQUE,
    coefficient DECIMAL(10,2) NOT NULL
);


CREATE TABLE material_types (
    material_type_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL UNIQUE,
    loss_percent DECIMAL(5,2) NOT NULL
);

CREATE TABLE workshops (
    workshop_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL UNIQUE,
    workshop_type NVARCHAR(255),
    workers_count INT
);

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_type_id INT NOT NULL,
    sku NVARCHAR(50) NOT NULL UNIQUE,
    name NVARCHAR(255) NOT NULL,
    min_partner_price DECIMAL(10,2),
    main_material_id INT NOT NULL,
    FOREIGN KEY (product_type_id) REFERENCES product_types(product_type_id),
    FOREIGN KEY (main_material_id) REFERENCES material_types(material_type_id)
);

CREATE TABLE production_workshops (
    product_id INT NOT NULL,
    workshop_id INT NOT NULL,
    PRIMARY KEY (product_id, workshop_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (workshop_id) REFERENCES workshops(workshop_id)
);


Создание БД - 

IF DB_ID('mebel') IS NULL
BEGIN
    CREATE DATABASE mebel;
END
GO


создание внешних ключей - 

ALTER TABLE Product
ADD CONSTRAINT FK_Product_ProductType
ADD CONSTRAINT FK_Product_MaterialType
    FOREIGN KEY (product_type_id) REFERENCES product_types(product_type_id),
    FOREIGN KEY (main_material_id) REFERENCES material_types(material_type_id)
);


  ALTER TABLE ProductWorkshop
  ADD CONSTRAINT FK_ProductWorkshop_Workshop
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (workshop_id) REFERENCES workshops(workshop_id)
);
