package demos.dm01Brewary;

import demos.dm01Brewary.beers.*;

public class Main {

	public static void main(String[] args) throws Exception {
		Brewary brewary = new Brewary();
		long start = System.nanoTime();
		for (int i = 0; i < 100000; i++) {
			Beer beer = brewary.brew("Shumensko", 10);
		}
		System.out.println(System.nanoTime() - start);
	}
}
