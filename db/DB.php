<?php

class DB {
    public static function get() {
        return new PDO(
           "mysql:dbname=piskvorky;host:127.0.0.1",
            "root",
            ""
        );
    }
}