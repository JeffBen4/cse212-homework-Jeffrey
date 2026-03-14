using System;

using System;
using System.Collections.Generic; // REGLA DE ORO: Siempre agrégalo para usar Listas

public class Program
{
    static void Main(string[] args)
    {
        // --- 1. CREACIÓN Y EMPTY() ---
        List<string> inventario = new List<string>();
        
        // Verificamos si está vacía (empty)
        Console.WriteLine($"¿El inventario está vacío?: {inventario.Count == 0}");

        // --- 2. APPEND (Añadir al final) ---
        // Usamos .Add()
        inventario.Add("Espada");
        inventario.Add("Escudo");
        inventario.Add("Poción");
        
        
        // --- 3. SIZE() Y CAPACITY() ---
        // .Count nos da el tamaño actual y .Capacity el espacio reservado
        Console.WriteLine($"\nDespués de añadir items:");
        Console.WriteLine($"Tamaño (Size): {inventario.Count}"); 
        Console.WriteLine($"Capacidad: {inventario.Capacity}");

        // --- 4. LOOKUP (Buscar por índice) ---
        // Usamos los corchetes [index]
        string primerItem = inventario[0];
        Console.WriteLine($"\nEl primer item (índice 0) es: {primerItem}");

        // --- 5. INSERT (Insertar en un lugar específico) ---
        // Metemos un "Mapa" en el índice 1. 
        // El Escudo y la Poción se mueven a la derecha.
        Console.WriteLine("\n[Acción]: Insertando 'Mapa' en el índice 1...");
        inventario.Insert(1, "Mapa");

        
        // --- 6. REMOVE (Eliminar por índice) ---
        // Quitamos el item del índice 2 (que ahora es el Escudo)
        // La Poción se mueve a la izquierda para llenar el hueco.
        Console.WriteLine("[Acción]: Eliminando el item del índice 2...");
        inventario.RemoveAt(2); 

        
        // --- 7. RECORRIDO FINAL (Foreach) ---
        Console.WriteLine("\n--- INVENTARIO FINAL ---");
        foreach (var item in inventario)
        {
            Console.WriteLine("- " + item);
        }

        // Verificamos de nuevo el estado
        Console.WriteLine($"\n¿Está vacío ahora?: {inventario.Count == 0}");
        Console.WriteLine($"Tamaño final: {inventario.Count}");
    }
}