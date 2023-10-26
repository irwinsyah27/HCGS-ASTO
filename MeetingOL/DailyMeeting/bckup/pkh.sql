-- phpMyAdmin SQL Dump
-- version 2.10.3
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Waktu pembuatan: 20. Mei 2011 jam 12:39
-- Versi Server: 5.0.51
-- Versi PHP: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

-- 
-- Database: `pkh`
-- 

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `c2`
-- 

CREATE TABLE `c2` (
  `NoC2` int(11) NOT NULL auto_increment,
  `NoDept` int(11) NOT NULL,
  `Tipe` enum('CM','C') NOT NULL,
  `Complaint` text NOT NULL,
  `NumberC` int(11) NOT NULL,
  `NumberCm` int(11) NOT NULL,
  `ResultC` int(11) NOT NULL,
  `ResultCm` int(11) NOT NULL,
  `Remark` text NOT NULL,
  PRIMARY KEY  (`NoC2`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `dailymeeting`
-- 

CREATE TABLE `dailymeeting` (
  `NoDM` int(11) NOT NULL auto_increment,
  `NoDept` int(11) NOT NULL,
  `TglDM` date NOT NULL,
  `Items` enum('A','B','C','D','E') NOT NULL,
  `Plan1` int(11) NOT NULL default '0',
  `Plan2` int(11) NOT NULL default '0',
  `Plan3` int(11) NOT NULL default '0',
  `Actual1` int(11) NOT NULL default '0',
  `Actual2` int(11) NOT NULL default '0',
  `Actual3` int(11) NOT NULL default '0',
  `Remark1` varchar(30) NOT NULL,
  `Remark2` varchar(30) NOT NULL,
  `Remark3` varchar(30) NOT NULL,
  `MPP` int(11) NOT NULL,
  `Sakit` int(11) NOT NULL,
  `Izin` int(11) NOT NULL,
  `Alpha` int(11) NOT NULL,
  `NoC2` int(11) NOT NULL,
  `Information` text NOT NULL,
  `Lampiran` varchar(50) NOT NULL,
  `FileA` varchar(80) NOT NULL,
  `Type` varchar(30) NOT NULL,
  `TglUpdate` datetime NOT NULL,
  `UserUpdate` varchar(30) NOT NULL,
  `On` int(11) NOT NULL default '1',
  PRIMARY KEY  (`NoDM`),
  KEY `NoSec` (`Items`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `departemen`
-- 

CREATE TABLE `departemen` (
  `NoDept` int(11) NOT NULL auto_increment,
  `NamaDept` varchar(30) NOT NULL,
  `DeptHead` varchar(50) NOT NULL,
  PRIMARY KEY  (`NoDept`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `pkh`
-- 

CREATE TABLE `pkh` (
  `NoPKH` int(11) NOT NULL auto_increment,
  `TglPK` date NOT NULL,
  `NoSec` int(11) NOT NULL,
  `Sejak` date NOT NULL,
  `Lokasi` varchar(30) NOT NULL,
  `Instruksi_Kerja` text NOT NULL,
  `Laporan_Pelaksanaan` text NOT NULL,
  `Status` enum('Open','Close','No Progress') NOT NULL,
  `Kondisi` enum('0','1','2') NOT NULL,
  `Lampiran` varchar(50) NOT NULL,
  `File` mediumblob NOT NULL,
  `Type` varchar(30) NOT NULL,
  `TglUpdate` datetime NOT NULL,
  `UserUpdate` varchar(30) NOT NULL,
  `On` int(11) NOT NULL default '1',
  PRIMARY KEY  (`NoPKH`),
  KEY `NoSec` (`NoSec`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=784 ;

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `secdept`
-- 

CREATE TABLE `secdept` (
  `NoSec` int(11) NOT NULL auto_increment,
  `NamaSec` varchar(30) NOT NULL,
  `NoDept` int(11) NOT NULL,
  PRIMARY KEY  (`NoSec`),
  KEY `NoDept` (`NoDept`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=41 ;

-- --------------------------------------------------------

-- 
-- Struktur dari tabel `user`
-- 

CREATE TABLE `user` (
  `NRP` varchar(30) NOT NULL,
  `Nama` varchar(50) NOT NULL,
  `NoSec` int(11) NOT NULL,
  `Password` varchar(30) NOT NULL default 'persada',
  PRIMARY KEY  (`NRP`),
  KEY `NoSec` (`NoSec`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
-- 

-- 
-- Ketidakleluasaan untuk tabel `pkh`
-- 
ALTER TABLE `pkh`
  ADD CONSTRAINT `pkh_ibfk_1` FOREIGN KEY (`NoSec`) REFERENCES `secdept` (`NoSec`);

-- 
-- Ketidakleluasaan untuk tabel `secdept`
-- 
ALTER TABLE `secdept`
  ADD CONSTRAINT `secdept_ibfk_1` FOREIGN KEY (`NoDept`) REFERENCES `departemen` (`NoDept`);

-- 
-- Ketidakleluasaan untuk tabel `user`
-- 
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`NoSec`) REFERENCES `secdept` (`NoSec`);
