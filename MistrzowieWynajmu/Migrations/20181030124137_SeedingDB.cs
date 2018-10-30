using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MistrzowieWynajmu.Migrations
{
    public partial class SeedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, PhoneNumber) VALUES ('Tomasz','Kempa', '556667888')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, PhoneNumber) VALUES ('Sebastian','Spaloniak', '666106450')");
            migrationBuilder.Sql("INSERT INTO Owners (Name, Surname, PhoneNumber) VALUES ('Jan','Kowalski', '666777888')");

            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Lwowska','Rzeszów')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Żurawia','Czerwonak')");
            migrationBuilder.Sql("INSERT INTO Addresses (Street, City) VALUES ('Stroma','Warszawa')");

            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Fridge, Iron, AddressId, OwnerId) VALUES (1, 'Opis1', 8, 150, 1, 1, 1, 1, 1)");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Fridge, Iron, AddressId, OwnerId) VALUES (2, 'Opis2', 4, 74, 0, 1, 0, 2, 2)");
            migrationBuilder.Sql("INSERT INTO Properties (Type, Description, Rooms, Area, Washer, Fridge, Iron, AddressId, OwnerId) VALUES (1, 'Opis3', 6, 100, 1, 0, 1, 3, 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Owners");
            migrationBuilder.Sql("DELETE FROM Addresses");
            migrationBuilder.Sql("DELETE FROM Properties");
        }
    }
}
