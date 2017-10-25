package egged.hourbank.jdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

public class DbDml {
	
	
	
	

public static void deleteRecordFromTable( String sdescription ) throws SQLException {
	 
	Connection dbConnection = null;
	Statement statement = null;
	
	
	
	String deleteTableSQL1 = "DELETE from TB_BUDGET_SPECIAL where DESCRIPTION="+sdescription+"";
	//String deleteTableSQL2 = "DELETE from TB_SIDURIM_OVDIM where mispar_ishi="+sishi+" and taarich = "+staarich+" and mispar_sidur= "+smispar_sidur+"";
			

	try {
		dbConnection = getDBConnection();
		statement = dbConnection.createStatement();

		//System.out.println(deleteTableSQL);

		// execute delete SQL statement
		statement.execute(deleteTableSQL1);
		//statement.execute(deleteTableSQL2);

		System.out.println("Record is deleted from DBUSER table!");

	} catch (SQLException e) {

		System.out.println(e.getMessage());

	} finally {

		if (statement != null) {
			statement.close();
		}

		if (dbConnection != null) {
			dbConnection.close();
		}

	}

}








private static Connection getDBConnection() {

	 String DB_CONNECTION = "jdbc:oracle:thin:@oracledev:1521:kdstst";
	 String DB_USER = "HOUR_BANK";
	 String DB_PASSWORD = "HB19GKM";
	Connection dbConnection = null;

	try {

		Class.forName("oracle.jdbc.driver.OracleDriver");

	} catch (ClassNotFoundException e) {

		System.out.println(e.getMessage());

	}  

	try {

		dbConnection = DriverManager.getConnection(
                         DB_CONNECTION, DB_USER,DB_PASSWORD);
		return dbConnection;

	} catch (SQLException e) {

		System.out.println(e.getMessage());

	}

	return dbConnection;

}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

}
