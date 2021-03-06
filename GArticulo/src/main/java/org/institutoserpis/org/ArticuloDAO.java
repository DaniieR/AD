package org.institutoserpis.org;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

import org.hamcrest.SelfDescribing;

/*
 
 0 SALIR
 1 NUEVO --> NOMBRE,PRECIO,CATEGORIA --> INSERT 
 2 MODIFICAR --> TODOS --> UPDATE
 3 ELIMINAR --> id --> DELETE ... WHERE
 4 CONSULTAR --> id --> SELECT ... WHERE
 5 LISTAR TODOS  --> SELECT
 
 */

public class ArticuloDAO {
	public static void main(String[] args) throws SQLException {
			Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "sistemas");
			Scanner sc = new Scanner(System.in);
			int opcion;
			do {
				System.out.println("---------------------");
				System.out.println("SELECCIONE UNA OPCION");
				System.out.println("---------------------");			
				System.out.println("0 SALIR");
				System.out.println("1 NUEVO");
				System.out.println("2 MODIFICAR");
				System.out.println("3 ELIMINAR");
				System.out.println("4 CONSULTAR");
				System.out.println("5 LISTAR TODOS");
				System.out.println("---------------------");
				opcion = sc.nextInt();
				switch (opcion) {
				case 1:
					Insertar(connection);
					break;
				case 2:
					Modificar(connection);
					break;
				case 3:
					Eliminar(connection);
					break;
				case 4:
					Consultar(connection);					
					break;
				case 5:
					listar_todo(connection);
					break;
				default:
					break;
				}
			} while (opcion!=0);
			connection.close();
		}
	public static void listar_todo(Connection connection)throws SQLException {
		Statement statement = connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo");
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre","precio","categoria" );
		while (resultSet.next()){
			System.out.printf("%5s %-30s %10s %9s\n",resultSet.getObject("id"),
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria"));
		}		
	}
	public static void Consultar(Connection connection)throws SQLException {
		Scanner sc = new Scanner(System.in);
		PreparedStatement preparedStatement = connection.prepareStatement("Select * from articulo where id = ?");
		System.out.println("SELECCIONE UN ID PARA CONSULTAR: ");
		preparedStatement.setObject(1, sc.nextInt());
		ResultSet resultSet = preparedStatement.executeQuery();
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre","precio","categoria" );
		while (resultSet.next()){
			System.out.printf("%5s %-30s %10s %9s\n",resultSet.getObject("id"),
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria"));
		}		
	}
	public static void Eliminar(Connection connection)throws SQLException {
		Scanner sc = new Scanner(System.in);
		PreparedStatement preparedStatement = connection.prepareStatement("Delete from articulo where id = ?");
		System.out.println("SELECCIONE UN ID PARA ELIMINAR: ");
		preparedStatement.setObject(1, sc.nextInt());
		preparedStatement.executeUpdate();	
	}
	public static void Insertar(Connection connection)throws SQLException {
		Scanner sc = new Scanner(System.in);
		PreparedStatement preparedStatement = connection.prepareStatement("INSERT INTO articulo (nombre, precio, categoria) VALUES (?, ?, ?)");
		System.out.println("INTRODUZCA UN NOMBRE");
		preparedStatement.setObject(1, sc.nextLine());
		System.out.println("INTRODUZCA UN PRECIO");
		preparedStatement.setObject(2, sc.nextInt());
		System.out.println("INTRODUZCA UNA CATEGORIA");
		preparedStatement.setObject(3, sc.nextInt());		 
		int rowsInserted = preparedStatement.executeUpdate();
		if (rowsInserted > 0) {
		    System.out.println("Se ha añadido un nuevo articulo correctamente");	
		}
	}
	public static void Modificar(Connection connection)throws SQLException {
		listar_todo(connection);
		Scanner sc = new Scanner(System.in);
		PreparedStatement preparedStatement = connection.prepareStatement("Update articulo SET nombre=?, precio=?, categoria=? WHERE id = ?");
		System.out.println("SELECCIONE UN ID PARA MODIFICAR: ");
		preparedStatement.setObject(4, Integer.parseInt(sc.nextLine()));
		System.out.println("INTRODUZCA EL NOMBRE: ");
		preparedStatement.setObject(1, sc.nextLine());
		System.out.println("INTRODUZCA EL PRECIO: ");
		preparedStatement.setObject(2, Integer.parseInt(sc.nextLine()));
		System.out.println("INTRODUZCA EL CATEGORIA: ");
		preparedStatement.setObject(3, Integer.parseInt(sc.nextLine()));		 
		int rowsUpdated = preparedStatement.executeUpdate();
		if (rowsUpdated > 0) {
		    System.out.println("Ha sido modificada una fila con exito");
		}
	}
}
