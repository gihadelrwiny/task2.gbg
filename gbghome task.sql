CREATE TABLE Books(
BookId int IDENTITY(1,1)PRIMARY KEY,
pages_number int ,
ISBN VARCHAR(20) UNIQUE,

)
CREATE TABLE Authors(
AuthorId int IDENTITY(1,1)PRIMARY KEY,
Author_Name  NVARCHAR(50) ,
)
CREATE TABLE Members(
MemberId int IDENTITY(1,1)PRIMARY KEY,
Member_Name NVARCHAR(50),
)
CREATE TABLE BorrowRecords(
BorrowId int IDENTITY(1,1)PRIMARY KEY,
BorrowDate Date Default GETDATE(),
ReturnDate Date ,
 CONSTRAINT CHK_ReturnDate
   CHECK (ReturnDate >= BorrowDate),
MemberID int,
BookId int,
)
Alter table BorrowRecords
ADD CONSTRAINT FK_Borrow_Member1
FOREIGN KEY (MemberID)
REFERENCES Members(MemberId);

Alter table BorrowRecords
ADD CONSTRAINT FK_Borrow_book
FOREIGN KEY (BookId)
REFERENCES Books(BookId);


Create table BookAuthor(
BookId int ,
AuthorId int,
primary key(BookId,AuthorId ),
Foreign key (BookId) references Books(BookId),
Foreign key (AuthorId) references Authors(AuthorId),

)
INSERT INTO Books (pages_number, ISBN)
VALUES 
(200, 'ISBN-001'),
(350, 'ISBN-002'),
(150, 'ISBN-003');
INSERT INTO Books (pages_number, ISBN)
VALUES 
(500, 'ISBN-004'),
(250, 'ISBN-005');

INSERT INTO Authors (Author_Name)
VALUES 
('Ahmed Ali'),
('Sara Mohamed'),
('Omar Hassan');

INSERT INTO Members (Member_Name)
VALUES 
('Gihad'),
('Mona'),
('Youssef');

INSERT INTO BorrowRecords (BorrowDate, ReturnDate, MemberID, BookId)
VALUES 
('2026-05-01', '2026-05-10', 1, 1),
('2026-05-03', '2026-05-12', 2, 2),
('2026-05-05', '2026-05-15', 3, 3);
--insert again to cases of select
INSERT INTO BorrowRecords (BorrowDate, ReturnDate, MemberID, BookId)
VALUES 
('2026-05-06', NULL, 1, 1),
('2026-05-07', NULL, 1, 2),
('2026-05-08', NULL, 1, 3),
('2026-05-09', NULL, 1, 4);

INSERT INTO BookAuthor (BookId, AuthorId)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(1, 2),


use GBG2;

Select b.BookId,b.pages_number,a.Author_Name 
from Books b
inner join   BookAuthor ba on  ba.BookId=b.BookId
inner join Authors a on a.AuthorId=ba.AuthorId;


select Member_Name from
Members m
inner join BorrowRecords br ON m.MemberId=br.MemberID
where  br.ReturnDate is null

SELECT 
    m.Member_Name,
    COUNT(br.BorrowId) AS TotalBorrows
FROM Members m
inner JOIN BorrowRecords br 
    ON m.MemberId = br.MemberID
GROUP BY m.Member_Name;

SELECT 
    m.Member_Name,
    COUNT(br.BorrowId) AS TotalBorrows
FROM Members m
inner JOIN BorrowRecords br 
    ON m.MemberId = br.MemberID
GROUP BY m.Member_Name
HAVING  COUNT(br.BorrowId)>2

select b.BookId from Books b
left  join BorrowRecords br on b.BookId=br.BookId
where br.BookId is null;

select m.Member_Name,count(br.BorrowId) as Totalborrow,

  case 
    when count(br.BorrowId)>=2 then 'Active'
    else 'Occasional'
     END AS MemberType
from members m
inner join BorrowRecords br on br.MemberID=m.MemberId
group by m.Member_Name
