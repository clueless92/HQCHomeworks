package demos.dm01Brewary;

import demos.dm01Brewary.beers.*;

public class Brewary {

	private static final String BEER_PACKAGE = "demos.dm01Brewary.beers.";

	public Beer brew(String beerType, int quantity) {
		Beer beer = null;
		switch (beerType) {
			case "Shumensko":
				beer = new Shumensko(quantity);
				break;
			case "Kamenitza":
				beer = new Kamenitza(quantity);
				break;
			case "Zagorka":
				beer = new Zagorka(quantity);
				break;
			default:
				throw new RuntimeException("Invalid beer!");
		}

		return beer;

//		Beer beer = null;
//		try {
//			Class beerClass = Class.forName(BEER_PACKAGE + beerType);
//			Constructor beerCtor = beerClass.getConstructor(int.class);
//			beer = (Beer) beerCtor.newInstance(quantity);
//		} catch (ReflectiveOperationException e) {
//			throw new RuntimeException("Invalid beer!");
//		}
//
//		return beer;
	}
}
