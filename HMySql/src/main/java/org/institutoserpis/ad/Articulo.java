package org.institutoserpis.ad;

import java.math.BigDecimal;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity
public class Articulo {
	private long Id;
	private String nombre;
	private BigDecimal precio;
	private Categoria categoria;

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
	public BigDecimal getprecio() {
		return precio;
	}
	public void setprecio(BigDecimal precio) {
		this.precio = precio;
	}
	@ManyToOne
	@JoinColumn(name="categoria")
	public Categoria getCategoria(){
		return categoria;
	}
	public void setCategoria(Categoria categoria){
		this.categoria=categoria;
	}
	@Override
	public String toString() {
		return String.format("%s %s %s (categoria=%s)", Id, nombre, precio, categoria);
	}
}
