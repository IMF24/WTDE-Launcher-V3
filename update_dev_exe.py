# -----------------------------
# COPY TO DEVELOPERS' REPOSITORY
# Copies the EXE in the Build folder to the dev repo, simple!
# -----------------------------
import os as OS, shutil as SHUT

print("Copying EXE to developers' repository...")

# Source and destination!
# For the current user, make sure we set the `dest` variable up right!
src = "./bin/Debug/GHWT_Definitive_Launcher.exe"

# Source file exists?
if (not OS.path.exists(src)):
    print("Source file does not exist!\n (Have you compiled a build yet?)")
    exit(0)

# Destination path exists?
dest = input("? Enter the path to the WTDE developers repository. >> ")
while (not OS.path.exists(f"{dest}/Packages/ghde_content/Content")):
    print("Destination directory does not exist!\n (Are you sure you have the directory set correctly?)\n\nEnter a valid path and try again.\n")
    dest = input("? Enter the path to the WTDE developers repository. >> ")

# Remove the old one and copy the new one!
out_dir = OS.path.join(dest, "GHWT_Definitive_Launcher.exe")
if (OS.path.exists(out_dir)): OS.remove(out_dir)
SHUT.copy(src, out_dir)

print("EXE copied to ghde_content package!")
input("? All done! Press ENTER to exit. >> ")