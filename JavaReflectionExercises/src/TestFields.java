import org.junit.Test;

import java.math.*;
import java.util.*;
import java.util.function.*;

public class TestFields {

	public static void hello(int name) {
		System.out.println("Hello, " + name);
	}

	@Test
	public void hello() {
		System.out.println("Hello, ");
	}

	public static final transient int testInt = 5;
	public Double testDouble = 5d;
	private String testString = "Peshoslav";
	private long testLong;
	protected double aDouble;
	public String aString;
	private Calendar aCalendar;
	public StringBuilder aBuilder;
	private char testChar;
	public short testShort;
	protected byte testByte;
	public byte aByte;
	protected StringBuffer aBuffer;
	private BigInteger testBigInt;
	protected BigDecimal testBigDecimal;
	public boolean testBoolean;
	private boolean aBoolean;
	protected float testFloat;
	public float aFloat;
	private Thread aThread;
	public Thread testThread;
	public Comparator testComparator;
	private Comparator aComparator;
	protected Supplier aSupplier;
	public Supplier testSupplier;
	private Consumer aConsumer;
	protected Consumer testConsumer;
	public Function testFunction;
	private Function aFunction;
	private Predicate aPredicate;
	protected Predicate testPredicate;
}
