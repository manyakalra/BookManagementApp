create table AUTHORS(
	id varchar(50) primary key,
	name varchar(50) not null,
	biography varchar(2000),
	photo varchar(256),
	email varchar(100)

);

create table USERS(
	email varchar(50) primary key,
	password varchar(50) not null,
	name varchar(100) not null,
	profile_photo varchar(256),
);

create table PUBLISHERS(
	id varchar(50) primary key,
	name varchar(100) not null,
	address varchar(100) not null,
	website varchar(100) not null
);

create table Tags(
	tag varchar(50) primary key
);



create table BOOKS(
	id varchar(100) primary key,
	title varchar(100) not null,
	description varchar(2000) not null,
	author_id varchar(50) not null,
	author_name varchar(100), --denormalized duplicate information
	cover_photo varchar(100), --duplicate information
	foreign key(author_id) references authors(id),
	
);

alter table books alter column cover_photo varchar(500)

create table BookTags(
	tag varchar(50) foreign key references Tags(tag),
	book_id varchar(100) foreign key references Books(id)
);

create table ISBNS(
	isbn varchar(15) primary key,
	book_id varchar(100) foreign key references books(id),
	publisher_id varchar(50) foreign key references publishers(id),
	cover_photo varchar(256) not null,
	price int not null,
	book_format varchar(10) default('paperback')
	
);

create table REVIEWS(
	id int identity primary key,
	reviewer_email varchar(100) foreign key references USERS(email),
	book_id varchar(100) foreign key references BOOKS(id),
	rating int,
	title varchar(50),
	details varchar(1000)
);

create table FAVORITES(
	id int identity primary key,
	book_id varchar(100) foreign key references BOOK(id),
	user_id varchar(100) foreign key references USERS(email),
	status varchar(10) default ('READING')
);

create table NOTES(
	id int identity primary key,
	favorites_id int foreign key references FAVORITES(ID),
	note_type varchar(10) default('content'),
	text varchar(1000),
	location int
);