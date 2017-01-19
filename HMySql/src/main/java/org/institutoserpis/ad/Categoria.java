package org.institutoserpis.ad;

import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.*;

@Entity
public class Categoria {
	private long Id;
	private String nombre;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	public long getId() {
		return Id;
	}
	public void setId(long id) {
		Id = id;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	@Override
	public String toString() {
		return String.format("%s %s", Id, nombre);
	}
}
