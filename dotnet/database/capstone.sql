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
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);
GO


CREATE TABLE breweries (
	brewery_id int IDENTITY(1,1) NOT NULL,
	brewery_name varchar(50) NOT NULL,
	brewery_address varchar(200) NOT  NULL,
	brewery_website varchar(200) NOT NULL,
	brewery_img varchar(1000) NOT NULL,
	brewery_description varchar(1000) NOT NULL,
	CONSTRAINT PK_breweries PRIMARY KEY (brewery_id)
);
GO

CREATE TABLE beers (
	beer_id int IDENTITY(1,1) NOT NULL,
	beer_name varchar(50) NOT NULL,
	beer_information varchar(1000) NOT NULL,
	beer_img varchar(1000) NOT NULL,
	CONSTRAINT PK_beers PRIMARY KEY (beer_id)
);
GO
CREATE TABLE beer_reviews (
	beer_review_id int IDENTITY(1,1) NOT NULL,
	beer_id int NOT NULL,
	reviewer_name varchar(50) NOT NULL,
	rating int NOT NULL,
	review_information varchar(1000) NOT NULL,
	CONSTRAINT PK_beer_reviews PRIMARY KEY (beer_review_id),
	CONSTRAINT [FK_beers_beer_reviews] FOREIGN KEY (beer_id) REFERENCES beers (beer_id),
);
GO
CREATE TABLE users_in_brewery(
	user_user_id int NOT NULL,
	user_brewery_id int NOT NULL,
	CONSTRAINT [PK_users_in_brewery] PRIMARY KEY
	(
	user_user_id ,
	user_brewery_id
	),
	CONSTRAINT [FK_users_users_in_brewery] FOREIGN KEY (user_user_id) REFERENCES users (user_id),
	CONSTRAINT [FK_breweries_users_in_brewery] FOREIGN KEY (user_brewery_id) REFERENCES breweries (brewery_id),
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
	CONSTRAINT [FK_brewery_beers_in_brewery] FOREIGN KEY (brewery_brewery_id) REFERENCES breweries (brewery_id),
	);
	GO

--populate default data

-- Robert/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Robert','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');

--Nancy/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('Nancy','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('a','gotJO35/Mqth5/5bmhHFaP+icNo=', 'dJltvp3LGG0=','brewer');

INSERT INTO users (username, password_hash, salt, user_role) VALUES ('b','BaFPd31aE5em14sB6Qxb/aQXatY=', '//XlquOKVis=','brewer');

INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_img,brewery_description) 
VALUES ('Knotty Pine Brewing','1765 W 3rd Ave, Columbus, OH 43212','https://www.knottypinebrewing.net/','','Casual brewpub serving American fare along with house-brewed beers & handcrafted cocktails.');
INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_img,brewery_description) 
VALUES ('Endevor Brewing & Spirits','909 W 5th Ave, Columbus, OH 43212','https://endeavorbrewing.com/','https://endeavorbrewing.com/wp-content/uploads/2022/01/Endeavor-Taproom.jpg','Endeavor is proud to be Columbus, Ohio’s first brewstillery. We locally craft a wide selection of internationally inspired beer styles, and select clear and wood aged spirits.
Visit our tap room and explore flavors gathered from our many adventures – from trekking through the Patagonia mountain range, van camping in Iceland, bike touring Bavaria, and walking the dog down the Olentangy trail.');
INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_img,brewery_description) 
VALUES ('The Ohio Taproom','1291 W 3rd Ave, Columbus, OH 43212','https://theohiotaproom.com/','','Plain and simple - We celebrate and sell only goods made in Ohio, starting with craft beer. We offer our Ohio-crafted beer in growlers of various sizes as well as beer canned freshly on site. Choose your favorite beer on draft, and we''ll use our canner to can as many beers as you''d like to take home with you. Guests can enjoy pints and samples on site, too. We''ve also got wine in bottles and cocktails made with Simple Times mixers on draft (check out tap #3 to see what cocktail''s on draft today.) We also sell other Ohio-made goods like pretzels, soda, mead, cider, BBQ sauce, ... pretty much the best we''ve found from around this great state.');
INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_img,brewery_description) 
VALUES ('Columbus Brewing Co.','2555 Harrison Rd, Columbus, OH 43204','https://columbusbrewing.com/','https://columbusbrewing.com/wp-content/uploads/2022/04/CBC-Origo-Powers-28.jpg','We''ve served the best beer in town for more than 30 years and while a lot has changed since 1988, our family is united by our passion to bring the best beer imaginable to Ohio for years to come.');
INSERT INTO breweries (brewery_name,brewery_address,brewery_website,brewery_img,brewery_description) 
VALUES ('Brewdog Franklinton','463 W Town St, Columbus, OH 43215','https://www.brewdog.com/uk/brewdog-franklinton','https://www.google.com/maps/uv?pb=!1s0x88388f3fa5ebffff%3A0xff6adbcee6017384!3m1!7e115!4shttps%3A%2F%2Flh5.googleusercontent.com%2Fp%2FAF1QipPKa692M9yX0YphScxMOqxzfudMZJUWEWpIEzeA%3Dw260-h175-n-k-no!5sbrewdog%20franklinton%20-%20Google%20Search!15sCgIgAQ&imagekey=!1e10!2sAF1QipPKa692M9yX0YphScxMOqxzfudMZJUWEWpIEzeA&hl=en&sa=X&ved=2ahUKEwio1Oanru37AhVIk4kEHYAjCdUQ7ZgBKAB6BAgiEAI#','With 48 taps of fresh craft beer, Franklinton is the answer. An absolutely incredible refurb of an old car mechanics shop featuring super high ceilings, street level patio as well as an epic roof terrace and bar! Right across the road from our friends Land Grant, we''re super excited to join the rising area of Franklinton. With 48 taps across two bars and a full kitchen, you don''t want to wait to check out BrewDog Franklinton.');

INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Knotty Pine Amber Ale','A moderate, hoppy beer with a distinct caramel malty flavor.',''); /*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Knotty Pine Midwest Grapefruit IPA','A bitter, moderately strong American pale ale that uses its clean, supporting malt to showcase its hop character.','');/*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Land Grant Can Flashes','A bitter, moderately strong American pale ale that uses its clean, supporting malt to showcase its hop character.','');/*Knotty Pine*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Altura Latin Lager','Inspired by our founders’ mountaineering in Chile, drinking unfiltered German pilsner, and all day tacos al pastor barbecues. An aroma of lime zest with flavors of sweet corn tortilla.',''); /*Endevor*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Holy Ground - Export Nitro Stout','Inspired by Pat’s family pilgrimages to the old world - warming up after a wet and windy seaside hike. Coffee and dark chocolate flavors give way to earthy hops and a velvety nitro finish. Brewed with malt from Cork, Ireland.','');/*Endevor*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Darkhaus - Dunkelweizen','Inspired by refusing to leave the biergarten, and a friend becoming a naturalized citizen. German style dark wheat ale with flavors of chocolate, banana, and spices.','');/*Endevor*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Columbus Brewing Emerald Gold IPA','Wet hopped hazy IPA brewed with fresh picked El Dorado hops from CLS Farms.','');/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Masthead Sleigh All Day','A bitter, moderately strong ale that carries some caramel and dark fruit malt character and finishes dry.','')/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Wolfs Ridge (614) Lager','Midwest Light Lager, only 110 calories. Brewed to be clean and crisp but with more flavor and allure than a macro lager. very lightly dry hopped with Huell Melon hops to add a subtle melon/citrus note to the aroma.','');/*Ohio Taproom*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Raspberry Lemon Chroma','Refreshingly tart with aromas of ripe lemon and raspberries. Pours pink in color.',''); /*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Smoke and Repeat','Pours copper in color and brewed with smoked Bavarian malt. Aromas of campfire smoke, fresh bread and caramel.','');/*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Brioso Cream Ale','Brewed with single-origin beans from Brioso Coffee. A brilliant, golden straw hue with a light and silky smooth body. Undertones of chocolate, vanilla, nuts and honey.','');/*Columbus Brewing*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Hellcat IPA','BrewDog USA partners with Iron Maiden to create a​ feisty India Pale Lager, citrus-forward with ​an epically complex balance of malts and hops.','');/*Brewdog*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Hazy Jane','East Coasts collide and crank it up for this new New England IPA returned in Scotland. Brewed with oats and wheat and left unfiltered for a hazy appearance and super smooth delivery. Dry-hopped for a full-tilt fruit hit with pineapple, mango and a hint of zesty lime. Low on bitterness, high on haze, heavy on hops.','');/*Brewdog*/
INSERT INTO beers (beer_name,beer_information,beer_img) 
VALUES ('Mixtape','Mixtape is a barrel-aged sour refermented w/ peach, mango and passionfruit, mint and Tahitian vanilla.','');/*Brewdog*/

--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('1','1');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('2','1');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('3','1');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('4','2');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('5','2');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('6','2');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('7','3');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('8','3');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('9','3');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('10','4');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('11','4');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('12','4');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('13','5');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('14','5');
--INSERT INTO beers_in_brewery (brewery_beer_id,brewery_brewery_id) VALUES ('15','5');
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 1),(select brewery_id from breweries where brewery_id = 1));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 2),(select brewery_id from breweries where brewery_id = 1));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 3),(select brewery_id from breweries where brewery_id = 1));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 4),(select brewery_id from breweries where brewery_id = 2));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 5),(select brewery_id from breweries where brewery_id = 2));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 6),(select brewery_id from breweries where brewery_id = 2));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 7),(select brewery_id from breweries where brewery_id = 3));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 8),(select brewery_id from breweries where brewery_id = 3));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 9),(select brewery_id from breweries where brewery_id = 3));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 10),(select brewery_id from breweries where brewery_id = 4));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 11),(select brewery_id from breweries where brewery_id = 4));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 12),(select brewery_id from breweries where brewery_id = 4));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 13),(select brewery_id from breweries where brewery_id = 5));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 14),(select brewery_id from breweries where brewery_id = 5));
INSERT INTO [beers_in_brewery](brewery_beer_id,brewery_brewery_id)
VALUES((select beer_id from  beers where beer_id = 15),(select brewery_id from breweries where brewery_id = 5));
GO

INSERT INTO [users_in_brewery](user_user_id,user_brewery_id)
VALUES((select user_id from  users where user_id = 3),(select brewery_id from breweries where brewery_id = 4));
INSERT INTO [users_in_brewery](user_user_id,user_brewery_id)
VALUES((select user_id from  users where user_id = 4),(select brewery_id from breweries where brewery_id = 5));
GO
SELECT * FROM users;
SELECT brewery_id, beer_id,beer_name,beer_information,beer_img FROM beers JOIN beers_in_brewery ON beers_in_brewery.brewery_beer_id=beers.beer_id JOIN breweries ON breweries.brewery_id= beers_in_brewery.brewery_brewery_id;


