use SwCommerce;
insert into Product
values ('1','Chocolate Wafer Bis ao Leite c/20 - Lacta',
'4.99','https://images-americanas.b2w.io/produtos/01/00/img/19602/9/19602908_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='2')),
('2','Chocolate Kit Kat ao Leite Nestlé 41,5g','2.99',
'https://images-americanas.b2w.io/produtos/01/00/oferta/44414/1/44414154_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='2')),
('3','Chocolate Bombom Ouro Branco 1kg Lacta','31.99',
'https://images-americanas.b2w.io/produtos/01/00/oferta/19583/0/19583072_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='1')),
('4','Chocolate Bombom Sonho De Valsa 1kg Lacta','31.99',
'https://images-americanas.b2w.io/produtos/01/00/item/19583/0/19583030_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='1')),
('5','Bala de Gelatina Beijos Morango 100g - Fini','4.69',
'https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889657g1.jpg',
(SELECT Id FROM Offer WHERE Id ='3')),
('6','Bala de Gelatina e Marshmallows Dentadura 100g - Fini','4.69',
'https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889655_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='3')),
('7','Bala de Gelatina Minhocas 100g - Fini','4.69',
'https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889649_1GG.jpg',
(SELECT Id FROM Offer WHERE Id ='3'));