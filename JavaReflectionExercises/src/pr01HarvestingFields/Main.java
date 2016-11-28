package pr01HarvestingFields;

import java.lang.annotation.*;

public class Main {
	public static void main(String[] args) throws Exception {
		Class soilClass = RichSoilLand.class;
		Annotation[] anots = soilClass.getDeclaredAnnotations();
		for (Annotation anot : anots) {
			System.out.println(anot.toString());
		}
	}
}
