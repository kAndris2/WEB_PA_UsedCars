--TABLES....................................................................................................
CREATE TABLE public.users
(
	id serial not null,
	name character varying(20) not null,
	registration_date bigint not null,
	gender bool,
	birth_date date not null,
	email character varying(30) not null,
	password character varying(20) not null,
	wallet int not null,
	rank character varying(15) not null,
	views int default 0,
	introduction character varying(255)
);

CREATE TABLE public.vehicles
(
	id serial not null,
	brand character varying(20) not null,
	model character varying(20) not null,
	vintage int not null,
	type character varying(20) not null,
	price int not null,
	fuel character varying(20) not null,
	cylinder_capacity int not null,
	odometer int not null,
	description text not null,
	shop_id int,
	user_id int,
	views int default 0,
	votes int default 0,
	validity bool not null
);

CREATE TABLE public.shops
(
	id serial not null,
	name character varying(25) not null,
	description character varying(255),
	foundation_date date,
	owner_id int not null,
	address character varying(30) not null,
	views int default 0
);

CREATE TABLE public.comments
(
	id serial not null,
	title character varying(50) not null,
	message character varying(255) not null,
	submission_time bigint not null,
	user_id int,
	vehicle_id int,
	shop_id int
);

CREATE TABLE public.purchases
(
	id serial not null,
	shop_id int not null,
	amount int not null,
	year int not null,
	brand character varying(20) not null
);

CREATE TABLE public.pictures
(
	id serial not null,
	route character varying(255) not null,
	user_id int,
	vehicle_id int,
	shop_id int
);

CREATE TABLE public.races
(
	id serial not null,
	type character varying(20) not null
);

--ADD PRIMARY KEY...........................................................................................
ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
	
ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT vehicles_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.shops
    ADD CONSTRAINT shops_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.purchases
    ADD CONSTRAINT purchases_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.pictures
    ADD CONSTRAINT pictures_pkey PRIMARY KEY (id);

ALTER TABLE ONLY public.races
    ADD CONSTRAINT races_pkey PRIMARY KEY (id);

--ADD FOREIGN KEY...........................................................................................
ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.vehicles
    ADD CONSTRAINT shop_id FOREIGN KEY (shop_id) REFERENCES public.shops(id) ON DELETE CASCADE;
	

ALTER TABLE ONLY public.shops
    ADD CONSTRAINT owner_id FOREIGN KEY (owner_id) REFERENCES public.users(id) ON DELETE CASCADE;
	

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.comments
    ADD CONSTRAINT vehicle_id FOREIGN KEY (vehicle_id) REFERENCES public.vehicles(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.comments
    ADD CONSTRAINT shop_id FOREIGN KEY (shop_id) REFERENCES public.shops(id) ON DELETE CASCADE;


ALTER TABLE ONLY public.purchases
    ADD CONSTRAINT shop_id FOREIGN KEY (shop_id) REFERENCES public.shops(id) ON DELETE CASCADE;


ALTER TABLE ONLY public.pictures
    ADD CONSTRAINT user_id FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.pictures
    ADD CONSTRAINT vehicle_id FOREIGN KEY (vehicle_id) REFERENCES public.vehicles(id) ON DELETE CASCADE;
ALTER TABLE ONLY public.pictures
    ADD CONSTRAINT shop_id FOREIGN KEY (shop_id) REFERENCES public.shops(id) ON DELETE CASCADE;