USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);
GO

CREATE TABLE brewerys (
	brewery_id int IDENTITY(1,1) NOT NULL,
	brewery_name varchar(50) NOT NULL,
	brewery_zip varchar(200) NOT  NULL,
	brewery_website varchar(200) NOT NULL,
	CONSTRAINT PK_brewerys PRIMARY KEY (brewery_id)
);
GO

CREATE TABLE beers (
	beer_id int IDENTITY(1,1) NOT NULL,
	beer_name varchar(50) NOT NULL,
	beer_information varchar(1000) NOT NULL,
	CONSTRAINT PK_beers PRIMARY KEY (beer_id)
);
GO
CREATE TABLE beers_in_brewery(
	brewery_beer_id int NOT NULL,
	brewery_brewery_id int NOT NULL,
	CONSTRAINT [PK_beers_in_brewery] PRIMARY KEY
	(
	brewery_beer_id,
	brewery_brewery_id
	),
	CONSTRAINT [FK_beers_beers_in_brewery] FOREIGN KEY (brewery_beer_id) REFERENCES beers (beer_id),
	CONSTRAINT [FK_brewery_beers_in_brewery] FOREIGN KEY (brewery_brewery_id) REFERENCES brewerys (brewery_id),
	);
	GO

--populate default data

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO brewerys (brewery_name,brewery_zip,brewery_website) VALUES ('Knotty Pine Brewing','43212','https://www.knottypinebrewing.net/');
INSERT INTO brewerys (brewery_name,brewery_zip,brewery_website) VALUES ('Endevor Brewing & Spirits','43212','https://endeavorbrewing.com/');
INSERT INTO brewerys (brewery_name,brewery_zip,brewery_website) VALUES ('The Ohio Taproom','43212','https://theohiotaproom.com/');
INSERT INTO brewerys (brewery_name,brewery_zip,brewery_website) VALUES ('Columbus Brewing Co.','43204','https://columbusbrewing.com/');
INSERT INTO brewerys (brewery_name,brewery_zip,brewery_website) VALUES ('Brewdog Franklinton','43215','https://www.brewdog.com/uk/brewdog-franklinton');

INSERT INTO beers (beer_name,beer_information) VALUES ('Knotty Pine Amber Ale','A moderate, hoppy beer with a distinct caramel malty flavor.'); /*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Knotty Pine Midwest Grapefruit IPA','A bitter, moderately strong American pale ale that uses its clean, supporting malt to showcase its hop character.');/*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Land Grant Can Flashes','A bitter, moderately strong American pale ale that uses its clean, supporting malt to showcase its hop character.');/*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Altura Latin Lager','Inspired by our founders’ mountaineering in Chile, drinking unfiltered German pilsner, and all day tacos al pastor barbecues. An aroma of lime zest with flavors of sweet corn tortilla.'); /*Endevor*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Holy Ground - Export Nitro Stout','Inspired by Pat’s family pilgrimages to the old world - warming up after a wet and windy seaside hike. Coffee and dark chocolate flavors give way to earthy hops and a velvety nitro finish. Brewed with malt from Cork, Ireland.');/*Endevor*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Darkhaus - Dunkelweizen','Inspired by refusing to leave the biergarten, and a friend becoming a naturalized citizen. German style dark wheat ale with flavors of chocolate, banana, and spices.');/*Endevor*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Columbus Brewing Emerald Gold IPA','Wet hopped hazy IPA brewed with fresh picked El Dorado hops from CLS Farms');/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Masthead Sleigh All Day','A bitter, moderately strong ale that carries some caramel and dark fruit malt character and finishes dry.')/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Wolfs Ridge (614) Lager','Midwest Light Lager, only 110 calories. Brewed to be clean and crisp but with more flavor and allure than a macro lager. very lightly dry hopped with Huell Melon hops to add a subtle melon/citrus note to the aroma.');/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Raspberry Lemon Chroma','Refreshingly tart with aromas of ripe lemon and raspberries. Pours pink in color.'); /*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Smoke and Repeat','Pours copper in color and brewed with smoked Bavarian malt. Aromas of campfire smoke, fresh bread and caramel.');/*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Brioso Cream Ale','Brewed with single-origin beans from Brioso Coffee. A brilliant, golden straw hue with a light and silky smooth body. Undertones of chocolate, vanilla, nuts and honey.');/*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Hellcat IPA','BrewDog USA partners with Iron Maiden to create a​ feisty India Pale Lager, citrus-forward with ​an epically complex balance of malts and hops.');/*Brewdog*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Hazy Jane','East Coasts collide and crank it up for this new New England IPA returned in Scotland. Brewed with oats and wheat and left unfiltered for a hazy appearance and super smooth delivery. Dry-hopped for a full-tilt fruit hit with pineapple, mango and a hint of zesty lime. Low on bitterness, high on haze, heavy on hops. ');/*Brewdog*/
INSERT INTO beers (beer_name,beer_information) VALUES ('Mixtape','Mixtape is a barrel-aged sour refermented w/ peach, mango and passionfruit, mint and Tahitian vanilla. ');/*Brewdog*/

INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('1','1');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('2','1');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('3','1');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('4','2');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('5','2');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('6','2');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('7','3');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('8','3');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('9','3');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('10','4');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('11','4');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('12','4');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('13','5');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('14','5');
INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('15','5');
GO




