import java.lang.reflect.*;

public class Main {

	public static void main(String[] args) throws ReflectiveOperationException {
		Class<TestFields> testFieldsClass = TestFields.class;
		TestFields instance = testFieldsClass.newInstance();
		Field[] fields = testFieldsClass.getDeclaredFields();
//		for (Field field : fields) {
//			String mod = Modifier.toString(1024);
//			System.out.println(mod);
//		}

		for (int i = 1; i < 10000; i <<= 1) {
			String mod = Modifier.toString(i);
			System.out.println(mod);
		}
	}
}
