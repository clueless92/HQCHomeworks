package pr030405Barracks.core.factories;

import pr030405Barracks.contracts.Unit;
import pr030405Barracks.contracts.UnitFactory;

import java.lang.reflect.Constructor;

public class UnitFactoryImpl implements UnitFactory {

	private static final String UNITS_PACKAGE_NAME =
			"pr030405Barracks.models.units.";

	@Override
	public Unit createUnit(String unitType) {
		Unit unit = null;
		try {
			Class unitClass = Class.forName(UNITS_PACKAGE_NAME + unitType);
			Constructor ctor = unitClass.getConstructor();
			unit = (Unit) ctor.newInstance();
		} catch (ReflectiveOperationException rfe) {
			rfe.printStackTrace();
		}
		return unit;
	}
}
