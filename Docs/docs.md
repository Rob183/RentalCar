When deciding on the programming language, I choosed between Python, Java, and C#. I went with C#
because it is well-suited for GUI development and I had been wanting to work with it for some time.

Initially, I created a local JSON file for the database. However, I later decided to switch to an external
database because it is easy to manage data from different locations. In thinking of a future database expansion, 
NoSQL seemed like a good choice for my DB. I used an API to store the
data externally (on a Mongo DB Atals server), as NoSQL is easier to expand than SQL.

I wrote my program using the Model-View-Controller architecture. I placed the data in their own data classes,
with a model class for Car, Customer, and Booking. A GUI was intended for the view, which I have already started
working on (using .NET WPF).

The program creates one object each for the CarData, CustomerData, and BookingData classes, each with a list of
data. When the application is started, it queries the NoSQL database and stores the data as objects in the
lists. When new customers, bookings, or cars are created, they are saved in BSON format in the database.
   
Each customer can rent multiple cars. Each car can only be rented once at a time. Bookings are created based on the IDs of
the customer and car. The driven kilometers per booking are manually entered and added to the total kilometers
of the cars.
