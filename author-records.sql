

insert into authors(id,name,biography,photo,email) 
			values
			( 'mahatma-gandhi', 'Mohandas Karamchand Gandhi', 'The father of the nation, social reformer and freedom fighter', 'https://pbs.twimg.com/media/FAqPzrrUYAM8pCu.jpg',null),
			( 'jeffrey-archer', 'Jeffrey Archer', 'Best-selling British author, ex parliamentarian, ex convict','https://pbs.twimg.com/profile_images/3751745623/11bd5e198e1f0f7de40ffdf08f556293_400x400.jpeg','jeffrey.archer@gmail.com'),
			( 'john-grisham', 'John Grisham', 'Best-selling American author of Legal fiction', 'https://bloximages.newyork1.vip.townnews.com/djournal.com/content/tncms/assets/v3/editorial/2/75/275514ff-8984-5d76-a624-debb6e3ce788/5ef6431eae7ee.image.jpg?crop=746%2C746%2C330%2C6&resize=746%2C746&order=crop%2Cresize','john@grisham.net'),
			( 'vivek-dutta-mishra', 'Vivek Dutta Mishra', 'Author of The Accursed God and Manas', 'https://pbs.twimg.com/profile_images/1393255566928015360/i9qVt4oI_400x400.jpg','vivek@thelostepic.com'),
			( 'jk-rowling', 'JK Rowling', 'The World best selling author of Harry Potter Series','https://static.toiimg.com/thumb/msid-76027268,imgsize-96043,width-400,resizemode-4/76027268.jpg','jkr@harrypotterweb.net'),
			( 'dinkar', 'Ramdhari Singh Dinkar', 'The National Poet of India','https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg',null),
			( 'dumas', 'Alexandre Dumas', 'One of the altime greaterst author in English and French','https://cdn.vocab.com/units/h3ekjthk/author.jpg?width=400&v=176fc5c134d',null),
			( 'premchand', 'Munshi Premchand', 'The famous writer known as pen magician.','https://pbs.twimg.com/profile_images/1251088697203679233/fdW0tbbO_400x400.jpg',null)


insert into books(id,title,author_id, description,cover_photo)
			values
			(	'the-accursed-god',
			   	'The Accursed God','vivek-dutta-mishra',
				'An Amazon #1 best-seller, book#1 of The Lost Epic series, explores the unexplored facets of Mahabharata',
				'https://m.media-amazon.com/images/I/81c-qj2VZSL._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	'my-experiments-with-truth',
			   	'My Experiements with Truth','mahatma-gandhi',
				'The autobiography of Mahatma Gandhi presnted as his experiments with truth. A must read',
				'https://m.media-amazon.com/images/I/71GWX22G92L._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	'manas',
			   	'Manas','vivek-dutta-mishra',
				'An Amazon #1 best-seller, poetic tale of Mahabharata, best on authentic references',
				''
			),
			(	'the-count-of-monte-cristo',
			   	'The Count of Monte Cristo','dumas',
				'One of the altime greatest classic novel based in Napoleon era. A story of lover, betrayal and revenge',
				'https://m.media-amazon.com/images/I/61j4bBLKA4L._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	'harry-potter-1',
			   	'Harry Potter and the Philosophers stone','jk-rowling',
				'Part one of the great saga of Harry Potter and He who must not be named. The introduction to the great wizarding world',
				'https://www.amazon.in/Harry-Potter-Philosophers-Stone-Rowling-ebook/dp/B019PIOJYU/ref=sr_1_4?crid=2Q1YKYVGVSAUI&keywords=harry+potter&qid=1691570827&sprefix=harry+pott%2Caps%2C311&sr=8-4'
			),
			(	
				'harry-potter-2',
			   	'Harry Potter and the Chambers of Secret','jk-rowling',
				'As Harry Potter enters the chamber of secret to save someone he cares. And the true heir of voldamorte awaits',
				'https://m.media-amazon.com/images/I/81LFocwt-VL._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	
				'harry-potter-3',
			   	'Harry Potter and the Prisoner of Askaban','jk-rowling',
				'A prisoner escaped wizarding prison Askaban, the only who ever managed to. And incidently he may well be the traitor who led to the death of the parents of Harry Potter',
				'https://m.media-amazon.com/images/I/81RhPsqNIsL._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	
				'rashmirathi',
			   	'Rasmirathi','dinkar',
				'An epic poem in praise of Karna of Mahabharata',
				'https://m.media-amazon.com/images/I/81aCa8OAqNL._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	
				'kurukshetra',
			   	'kurukshetra','dinkar',
				'An epic poem, a conversastion between Bhisma and Yudhishthira about the necessity of war',
				'https://m.media-amazon.com/images/I/51rZ7I5lG8L._SX331_BO1,204,203,200_.jpg'
			),
			(	
				'the-brethren',
			   	'Brethren','john-grisham',
				'Story of three convicted judges and a presidential election',
				'https://m.media-amazon.com/images/I/81e82XI2xRL._AC_UY327_FMwebp_QL65_.jpg'
			),
			(	
				'kane-and-abel',
			   	'Kane and Abel','jeffrey-archer',
				'Story of two men born of same day on the opposite side of world and econmy and their growth till they encounter each other',
				'https://m.media-amazon.com/images/I/51YwwcnekOL._SY264_BO1,204,203,200_QL40_FMwebp_.jpg'
			);

insert into users (name,email,password,profile_photo) 
			values
			('Vivek Dutta Mishra','vivek@conceptarchitect.in','p@ss#1',''),
			('Sanjay Mall','sanjay@gmail.com','p@ss#1',''),
			('Amit Singh','amit@gmail.com','p@ss#1',''),
			('Prabhat Singh','prabhat@gmail.com','p@ss#1',''),
			('Fagun Pandya','fagun@gmail.com','p@ss#1',''),
			('Reena Upadhyaya','reena1234@gmail.com','p@ss#1','')

insert into Reviews(book_id, reviewer_email, rating,title,details)
			values( 'the-accursed-god','reena1234@gmail.com',5,'Must Read','The book offers a new perspective and great character buildup'),
			( 'the-accursed-god','fagun@gmail.com',4,'New Mahabharata','The story of Mahbharata told from different people perspective. Many new ideas'),
			( 'the-accursed-god','prabhat@gmail.com',5,'Must Read','Great story with so many unheard perspective'),
			( 'the-accursed-god','amit@gmail.com',5,'Must Read','Story that predates Mahabahrata as we know it. Worth a read'),
			( 'my-experiments-with-truth','vivek@conceptarchitect.in',5,'Must Read','The life of the greatest man of century lay bare. It gives his critcs many stones to hit him. And that probably is the greatest outcome of the experiment with truth'),
			( 'my-experiments-with-truth','sanjay@gmail.com',5,'Wonderful Experience','A brilliant peek into the life of the great man.'),
			( 'my-experiments-with-truth','reena1234@gmail.com',5,'Fantastic Read','I liked the story of Mahatma Gandhi and as he progressed from Mohandas to Mahtma'),
			( 'my-experiments-with-truth','fagun@gmail.com',4,'Great Man','My sir told me about his greatness. But is he or his story relevant for today?'),
			( 'my-experiments-with-truth','amit@gmail.com',1,'Overhyped','Gandhi is overhyped and so is his autobiography.'),
			( 'the-count-of-monte-cristo','vivek@conceptarchitect.in',5,'My Most Favorite Book, Ever','Read this over a 1000 page book at least four times. Everytime get a goosebump when Pheron is announced'),
			( 'rashmirathi','vivek@conceptarchitect.in',3,'My favorite book once','An spellbound poetry. simply brilliant. Alas! makes one of the most detestable person a hero.'),
			( 'harry-potter-1','amit@gmail.com',3,'Fairy Tale with no fairy','A good book. But looks over hyped'),
			( 'harry-potter-1','fagun@gmail.com',5,'Simply Brilliant','Wonderful book. And movies. thorowly enjoyed'),
			( 'harry-potter-2','fagun@gmail.com',5,'Great Part 2','A wonderful book with great part 2'),
			( 'manas','reena1234@gmail.com',5,'Fantastic','Fantastic Tale, Fantastic Poetry. Never new several hidden gems'),
			( 'manas','fagun@gmail.com',5,'Epic Hindi Poem','Reminds me of the writings of Ramdhari Singh Dinkar. Rare books are written originally in Hindi today are this good'),
			( 'manas','amit@gmail.com',5,'Epic Poem','Most poetries are two or thee paras. Here we have twelve chapters of 10-20 pages. And if that is not enough we have five bonus poems on Mahabharata')

insert into publishers(id,name,address,website)
			values('edu-world','Edu World', 'New Delhi',''),
			('the-lost-epic','The Lost Epic', 'Bangalore',''),
			('boomsbury','Boomsbury','UK',''),
			('penguine', 'Penguine India','India',''),
			('aksharan', 'Aksharan Publication', 'Pune, India',''),
			('prabhat','Prabhat Publication', 'India','')


insert into isbns(isbn,book_id,publisher_id,price,book_format,cover_photo)
			values('1234567891', 'the-accursed-god','edu-world',399, 'paperback','https://m.media-amazon.com/images/I/81c-qj2VZSL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567892', 'the-accursed-god','edu-world',480, 'hardbound','https://m.media-amazon.com/images/I/81c-qj2VZSL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567893', 'the-accursed-god','the-lost-epic',119, 'ebook','https://m.media-amazon.com/images/I/81c-qj2VZSL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567894', 'manas','the-lost-epic',99, 'ebook','https://m.media-amazon.com/images/I/71MvJTjRjPL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567895', 'manas','aksharan',199, 'paperback','https://m.media-amazon.com/images/I/71MvJTjRjPL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567896', 'harry-potter-1','boomsbury',419, 'paperback','https://m.media-amazon.com/images/I/5165He67NEL._SY346_.jpg'),
			('1234567897', 'harry-potter-1','boomsbury',119, 'ebook','https://m.media-amazon.com/images/I/917ti8nLcSL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567898', 'harry-potter-2','boomsbury',419, 'paperback','https://m.media-amazon.com/images/I/81LFocwt-VL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567899', 'harry-potter-2','boomsbury',119, 'ebook','https://m.media-amazon.com/images/I/81LFocwt-VL._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567900', 'the-count-of-monte-cristo','penguine',419, 'paperback','https://m.media-amazon.com/images/I/61j4bBLKA4L._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567901', 'the-count-of-monte-cristo','penguine',59, 'ebook','https://m.media-amazon.com/images/I/61j4bBLKA4L._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567902', 'rashmirathi','prabhat',119, 'paperback',''),
			('1234567903', 'rashmirathi','prabhat',49, 'ebook',''),
			('1234567904', 'my-experiments-with-truth','prabhat',219, 'paperback','https://m.media-amazon.com/images/I/71GWX22G92L._AC_UY327_FMwebp_QL65_.jpg'),
			('1234567905', 'my-experiments-with-truth','prabhat',119, 'ebook','https://m.media-amazon.com/images/I/61n0fz4OHBL._AC_UY327_FMwebp_QL65_.jpg')
			
			









			
