-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 24 Bulan Mei 2021 pada 20.40
-- Versi server: 10.4.16-MariaDB
-- Versi PHP: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbekskul`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tbanggota`
--

CREATE TABLE `tbanggota` (
  `id` int(11) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `tanggal_lahir` varchar(15) NOT NULL,
  `nomor_telepon` varchar(11) NOT NULL,
  `kelas` varchar(10) NOT NULL,
  `jabatan` varchar(20) NOT NULL,
  `angkatan` varchar(10) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tbanggota`
--

INSERT INTO `tbanggota` (`id`, `nama`, `tanggal_lahir`, `nomor_telepon`, `kelas`, `jabatan`, `angkatan`, `status`) VALUES
(1, 'Huang Renjun', '23 Maret 2000', '08132290108', '12 IPA 2', 'Seksi Acara', '2019', 'Selesai'),
(4, 'Zhong Chenle', '22 November 200', '08123274835', '11 IPA 3', 'Wakil Bendahara', '2020', 'Aktif');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tbanggota`
--
ALTER TABLE `tbanggota`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `tbanggota`
--
ALTER TABLE `tbanggota`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
