CREATE TABLE categories(
		id INT IDENTITY PRIMARY KEY,
		name VARCHAR(100) not null
);

CREATE TABLE products(
		id INT IDENTITY PRIMARY KEY, 
		categoryId INT not null, 
		name VARCHAR(100) not null, 
		description VARCHAR(250) not null, 
		price DECIMAL(10,2) not null, 
		stock INT not null, 
		image VARCHAR(250), 
		FOREIGN KEY (categoryId) REFERENCES categories(id)
)


SELECT *
FROM products
