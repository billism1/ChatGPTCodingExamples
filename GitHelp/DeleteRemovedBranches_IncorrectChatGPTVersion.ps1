# Fetch the latest changes from the remote and prune any deleted branches
git fetch --prune

# Get a list of all local branches
$local_branches = $(git branch --format '%(refname:short)')

# Get a list of all remote branches that have been deleted
$deleted_remote_branches = $(git branch -r --format '%(refname:short)' | Where-Object { $(git rev-parse $_@{upstream} 2>&1) -like '*not a valid*'})

# Loop through all local branches and delete any that have been deleted on the remote
foreach ($branch in $($local_branches | Where-Object { $deleted_remote_branches -contains $_ })) {
  git branch -D $branch
}
