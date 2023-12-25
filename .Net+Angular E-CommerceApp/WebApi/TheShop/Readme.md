# The Shop Api#
	Controllers:
	1. Products,
	2. Basket,
	3. Orders,
	4. Account





## Products ##

	Endpoints:

	### GetProducts###

	GET api/products

	Retrieve a paginated list of products based on specified parameters.

	Request:
	maxPageSize (int) (fromQuery) maximum amout of items returned
	PageIndex (int) (fromQuery) starting page
	BrandId (int) (fromQuery)
	maxPageSize (int) (fromQuery)
	TypeId (int) (fromQuery)
	Sort (string) (fromQuery)
	Search (string) (fromQuery)

	Response: {
	"pageIndex": int,
	"pageSize": int,
	"count": int,
	"data": [
    {
      "id": int,
      "name": string
      "description": string,
      "price": decimal,
      "pictureUrl": string,
      "productType": string,
      "productBrand": string
    },...]
	}

	Endpoints:

	### GetProductByID###

	GET /api/products/{id}

	Retrieve details about a specific product identified by its ID.

	Request:
	GET /api/products/1

	Response: {
	"id": int,
	"name": string,
	"description": string,
	"price": decimal,
	"pictureUrl": string,
	"productType": string,
	"productBrand": string
	}


	Endpoints:

	### GetProductBrands###

	GET /api/products/brands

	Retrieve a list of product brands.

	Request:
	GET /api/products/brands


    Response: [ {
    "name": string,
    "id": int
	},,...]
	

	]


	Endpoints:

	### GetProductTypes###

	GET /api/products/types

	Retrieve a list of product types.

	Request:
	GET /api/products/types

	Response: [ {
    "name": string,
    "id": int
	},,...]
	

## Basket ##

	Endpoints:

	### GetBasketById###

	GET /api/basket

	Retrieve a customer basket by its ID.

	Request:
	GET /api/basket?id={basketId}

	Response: {
	"id": int,
	"items": {
		"id": int,
        "productName": string,
		"price": int,
        "quantity": int,
        "pictureUrl": string,
        "brand": string,
        "type": string
		},
	"deliveryMethodId": string,
	"shippingPrice": int
	}

	Endpoints:

	### UpdateBasket###

	POST /api/basket/update

	Update a customer's basket with the provided data.

	Request: {
	"id": string,
	"items": [
    {
      "id": int,
      "productName": string,
      "price": int,
      "quantity": int,
      "pictureUrl": string,
      "brand": string,
      "type": string
    }
	],
	"deliveryMethodId": int,
	"shippingPrice": int
	}

	Response: {
	"id": string,
	"items": [
    {
      "id": int,
      "productName": string,
      "price": int,
      "quantity": int,
      "pictureUrl": string,
      "brand": string,
      "type": string
    }
	],
	"deliveryMethodId": int,
	"shippingPrice": int
	}


## Orders ##	

	Endpoints:

	### Create Order###

	POST /api/order

	Create a new order based on the provided order details.

	Request: {
	"basketId": string,
	"deliveryMethodId": int,
	"shipToAddress": {
    "firstName": string,
    "lastName": string,
    "street": string,
    "city": string,
    "state": string,
    "zipcode": string
	}
	}

	Response: {
	"id": int,
	"buyerEmail": string,
	"orderDate": string,
	"shipToAddress": {
    "firstName": string,
    "lastName": string,
    "street": string,
    "city": string,
    "state": string,
    "zipcode": string
	},
	"deliveryMethod": {
    "id": int,
    "shortName": string,
    "deliveryTime": string,
    "description": string,
    "price": int
	},
	"orderItems": [
    {
      "id": int,
      "itemOrdered": {
        "productItemId": int,
        "productName": string,
        "pictureUrl": string
      },
      "price": int,
      "quantity": int
    }
	],
	"subtotal": int,
	"status": string
	}

	Endpoints:

	### GetOrdersForUser###

	#### GET /api/order

	Retrieve a list of orders for the authenticated user.

	Request: 
	GET /api/order

	Response: {
	"id": int,
	"buyerEmail": string,
	"orderDate": string,
	"shipToAddress": {
    "firstName": string,
    "lastName": string,
    "street": string,
    "city": string,
    "state": string,
    "zipcode": string
	},
	"deliveryMethod": {
    "id": int,
    "shortName": string,
    "deliveryTime": string,
    "description": string,
    "price": int
	},
	"orderItems": [
    {
      "id": int,
      "itemOrdered": {
        "productItemId": int,
        "productName": string,
        "pictureUrl": string
      },
      "price": int,
      "quantity": int
    }
	],
	"subtotal": int,
	"status": string
	} 


	Endpoints:

	### GetOrderByIDForUser###

	#### GET /api/order/{id}

	Retrieve details about a specific order for the authenticated user.

	Request:
	GET /api/order/{id}

	Response: {
	"id": int,
	"buyerEmail": string,
	"orderDate": string,
	"shipToAddress": {
    "firstName": string,
    "lastName": string,
    "street": string,
    "city": string,
    "state": string,
    "zipcode": string
	},
	"deliveryMethod": {
    "id": int,
    "shortName": string,
    "deliveryTime": string,
    "description": string,
    "price": int
	},
	"orderItems": [
    {
      "id": int,
      "itemOrdered": {
        "productItemId": int,
        "productName": string,
        "pictureUrl": string
      },
      "price": int,
      "quantity": int
    }
	],
	"subtotal": int,
	"status": string
	} 

	Endpoints:

	### GetDeliveryMethods###

	#### GET /api/order/deliveryMethods

	Retrieve a list of available delivery methods.

	Request: 
	GET /api/order/deliveryMethods

	Response: {
    "id": int,
    "shortName": string,
    "deliveryTime": string,
    "description": string,
    "price": int
	}

## Account ##

	Endpoints:

	### GetCurrentUser###

	GET /api/user
	Authorization: token

	Retrieve details about the current authenticated user.

	Request:
	GET /api/user

	Response: {
	"email": "string",
	"displayName": "string",
	"token": "string"
	}

	Endpoints

	### GetUserAddress

	GET /api/user/address

	Retrieve the address of the authenticated user.

	Request: 
	GET /api/user/address
	Authorization: token

	Response: {
	"firstName": "string",
	"lastName": "string",
	"street": "string",
	"city": "string",
	"state": "string",
	"zipcode": "string"
	}

	Endpoints

	### Update User Address

	PUT /api/user/address

	Update the address of the authenticated user.

	Request:
	PUT /api/user/address
	Authorization: token

	{
	"firstName": "string",
	"lastName": "string",
	"street": "string",
	 "city": "string",
	 "state": "string",
	"zipcode": "string"
	}

	Response: {
	"firstName": "string",
	"lastName": "string",
	"street": "string",
	"city": "string",
	"state": "string",
	"zipcode": "string"
	}

	Endpoints

	### User Login

	POST /api/authentication/login

	Authenticate a user by providing valid login credentials.

	Request: {
	"email": "freddie@test.com",
	"password": "Pa$$w0rd"
	}

	Response: {
	"email": string,
	"displayName": string,
	"token": string
	}

	Endpoints

	### User Registration

	POST /api/authentication/register

	Register a new user by providing valid registration details.

	Request: {
	"displayName": string,
	"email": string,
	"password": string
	}

	Response: {
	"email": "string",
	"displayName": "string",
	"token": "string"
	}


	