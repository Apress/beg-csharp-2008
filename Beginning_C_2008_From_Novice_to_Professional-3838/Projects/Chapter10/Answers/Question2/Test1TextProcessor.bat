REM The idea with this question is to make you think out of the box
REM The test is one where you create a batch file and then use
REM those results with the diff program to verify that the generated
REM and reference files are identical
REM
TextProcessor.exe lotto.txt > out.main
diff out.main out.txt
