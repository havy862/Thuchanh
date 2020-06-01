CREATE DATABASE SinhVien


CREATE TABLE Lop
(
	MaLop varchar (5) NOT NULL PRIMARY KEY,
	TenLop nvarchar (50) NOT NULL,
	GVCN nvarchar (50) NOT NULL
);

CREATE TABLE SinhVien
(
	MaSV varchar (5) NOT NULL PRIMARY KEY,
	TenSV nvarchar (50) NOT NULL,
	NamSinh date,
	QueQuan nvarchar (100),
	MaLop varchar (5) NOT NULL,
	CONSTRAINT FK_MaLop FOREIGN KEY (MaLop) REFERENCES Lop (MaLop)
);

INSERT INTO Lop (MaLop, TenLop, GVCN)
VALUES ('ml01', N'Chuyên Toán', N'Nguyễn Lan Hương');
INSERT INTO Lop (MaLop, TenLop, GVCN)
VALUES ('ml02', N'Chuyên Lý', N'Tạ Hữu Dương');
INSERT INTO Lop (MaLop, TenLop, GVCN)
VALUES ('ml03', N'Chuyên Hóa', N'Nguyễn Hồng Phượng');

INSERT INTO SinhVien (MaSV, TenSV, NamSinh, QueQuan, MaLop)
VALUES ('sv001', N'Nguyễn Bích Ngọc', '2000-07-03', N'Hà Nội', 'ml03');
INSERT INTO SinhVien (MaSV, TenSV, NamSinh, QueQuan, MaLop)
VALUES ('sv002', N'Trần Trung Hiếu', '2000-07-22', N'Hà Nam', 'ml03');
INSERT INTO SinhVien (MaSV, TenSV, NamSinh, QueQuan, MaLop)
VALUES ('sv003', N'Lê Văn Thắng', '2000-05-11', N'Hà Tây', 'ml01');