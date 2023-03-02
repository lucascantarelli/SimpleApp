# Path: .git/hooks/pre-commit
define git_pre_commit
#!/bin/sh
cd $(git rev-parse --show-toplevel)
make format
endef
export git_pre_commit

# Path: .git/hooks/pre-push
define git_pre_push
#!/bin/sh
cd $(git rev-parse --show-toplevel)
make test
endef
export git_pre_push

git-hooks:
	@if [ -d .git/hooks ]; then \
		echo "$$git_pre_commit" > .git/hooks/pre-commit; \
		echo "$$git_pre_push" > .git/hooks/pre-push; \
		chmod +x .git/hooks/pre-*; \
	fi

format:
	@echo "Formatting code..."
	@for dir in ls -d */; do \
		if [ ! $$dir = "ls" ] && [ ! $$dir = "-d" ]; then \
			dotnet format $$dir --verbosity normal; \
		fi; \
	done

test:
	@dotnet test --no-build --verbosity normal