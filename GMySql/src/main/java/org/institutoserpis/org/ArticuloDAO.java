package org.institutoserpis.org;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ArticuloDAO {

	public static void main(String[] args) throws SQLException {
	//public static void main(String[] args) {
		Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
		PreparedStatement preparedStatement = connection.prepareStatement("Select * from articulo where id > ?");
		preparedStatement.setObject(1, Long.parseLong(args[0]));
		ResultSet resultSet = preparedStatement.executeQuery();
		//Statement statement = connection.createStatement();
		//ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo");
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre","precio","categoria" );
		while (resultSet.next()){
			System.out.printf("%5s %-30s %10s %9s\n",resultSet.getObject("id"),
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria"));
			//System.out.printf("     id=%5d\n", resultSet.getObject("id"));
		}
		preparedStatement.close();
		connection.close();
		System.out.println("fin");
	}

}
