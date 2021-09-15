-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 15, 2021 at 08:46 PM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `locadoraanimes`
--

-- --------------------------------------------------------

--
-- Table structure for table `animes`
--

CREATE TABLE `animes` (
  `idAnime` int(11) NOT NULL,
  `nomeAnime` varchar(100) NOT NULL,
  `categoriaAnime` varchar(60) NOT NULL,
  `sinopseAnime` text NOT NULL,
  `anoAnime` int(4) NOT NULL,
  `episodiosAnime` int(4) NOT NULL,
  `ativoAnime` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `animes`
--

INSERT INTO `animes` (`idAnime`, `nomeAnime`, `categoriaAnime`, `sinopseAnime`, `anoAnime`, `episodiosAnime`, `ativoAnime`) VALUES
(1, 'Shingeki no Kyojin (Attack on Titan)', 'Mistério, Pós-apocalipse, Fantasia sombria, Drama, Ação', 'Sendo atacados, um último punhado de sobreviventes da humanidade criam uma resistência em uma cidade com enormes muralhas para não serem extintos por monstros.', 2013, 75, 1),
(2, 'Tensei Shitara Slime Datta Ken', 'Fantasia, Aventura, Isekai', 'Adotando a forma de um slime, Rimuru tenta descobrir seu papel em um mundo completamente novo.', 2018, 24, 1),
(3, 'Goblin Slayer', 'Fantasia sombria, Ecchi, Seinen', 'Um aventureiro poderoso e inteligente escolhe gastar suas energias matando pequenos goblins, enquanto todos os outros aventureiros de seu nível se preocupam com monstros mais poderosos.', 2017, 13, 1),
(4, 'Overlord', 'Fantasia sombria, Humor negro, Isekai, ', 'Transportado para dentro de um jogo que consumiu muitas horas e esforço, Ainz Ooal Gown planeja a dominação mundial das pessoas usando sua supremacia e brutalidade.', 2015, 39, 1),
(5, 'Kono Subarashii Sekai ni Shukufuku wo! (Konosuba)', 'Comédia, Isekai, Fantasia cômica, Ecchi, Espada e Feitiçaria', 'Buscando uma vida de glória e aventuras, Kazuma percebe que a vida nesse novo mundo é muito mais difícil do que ele esperava.', 2016, 20, 1),
(6, 'Akame Ga Kill', 'Ação, Fantasia, Tragédia', 'Tatsumi quer entrar para o exército da capital. Pouco ele sabe que ela está infestada de corrupção. Tatsumi se junta a um grupo de assassinos que pretende destronar o imperador.', 2010, 24, 1),
(7, 'FullMetal Alchemist', 'Ficção, Aventura, Steampunk, Dieselpunk, Tragédia', 'Buscando recuperar seus corpos com alquimia, os irmãos Elric estão dispostos a enfrentar o mundo inteiro, se assim for necessário.', 2003, 51, 1),
(8, 'FullMetal Alchemist: Brotherhood', 'Ficção, Aventura, Steampunk, Dieselpunk, Tragédia', 'Buscando recuperar seus corpos com alquimia, os irmãos Elric estão dispostos a enfrentar o mundo inteiro, se assim for necessário. (Remake)', 2010, 64, 1),
(9, 'Chuunibyou Demo Koi Ga Shitai (Chuunibyou)', 'Comédia romântica', 'Superando traumas de infância e crises psicológicas, um grupo de adolescentes tenta entender seu lugar no mundo e como se comportar.', 2012, 12, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `animes`
--
ALTER TABLE `animes`
  ADD PRIMARY KEY (`idAnime`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `animes`
--
ALTER TABLE `animes`
  MODIFY `idAnime` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
