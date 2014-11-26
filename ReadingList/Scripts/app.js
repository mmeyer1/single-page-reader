var ViewModel = function () {
    var self = this;
    self.books = ko.observableArray();
    self.error = ko.observable();
    self.filter = ko.observable("");

    var booksUri = '/api/books/';
    var authorsUri = '/api/authors/';
    $('#authorInput').hide();
    $('#otherView').hide();

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }


    // Book-specific view methods
  function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
  }

    self.detail = ko.observable();

    self.clearDetail = function (detail) {
        self.detail(null);
    }

    self.getBookDetail = function (item) {
        ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.authors = ko.observableArray();
    self.newBook = {
        Author: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable(),
        Read: false
    }
    self.newAuthor = {
        Name:ko.observable()
    }

      function getAuthors() {
        ajaxHelper(authorsUri, 'GET').done(function (data) {
            self.authors(data);
        });
    }

    self.addBook = function (formElement) {
        var book = {
            AuthorId: self.newBook.Author().Id,
            Genre: self.newBook.Genre(),
            Price: self.newBook.Price(),
            Title: self.newBook.Title(),
            Year: self.newBook.Year(),
            Read: false
        };

        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.books.push(item);
            formElement.reset();
        });
    }
    
    self.toggleAuthorPanel = function () {
        $('#authorInput').toggle('slow');
    }

    self.deleteBook = function (book) {
        self.books.destroy(book);
        self.clearDetail(book);
        ajaxHelper(booksUri + book.Id, 'DELETE').done(function () {
            alert("Deleted " + book.Title);
        });
    };

    self.filteredBooks = ko.dependentObservable(function () {
        var filter = self.filter();
        if (!filter) {
            return self.books();
        } else {
            return ko.utils.arrayFilter(self.books(), function (item) {
                return (item.Title.indexOf(filter) !== -1);
            });
        }
    }, ViewModel);

    // Author-specific view methods

    self.addAuthor = function (formElement) {
        var author = { Name: self.newAuthor.Name() };

        ajaxHelper(authorsUri, 'POST', author).done(function (item) {
            self.authors.push(item);
            self.toggleAuthorPanel();
            formElement.reset();
            
        })
    }

    self.deleteAuthor = function (author) {
        self.authors.destroy(author);
        ajaxHelper(authorsUri + author.Id, 'DELETE').done(function () {
            alert("Removed the author: " + author.Name);
            getAllBooks(); // This isn't very efficient, need to iterate through all books and do a targeted hiding of the related objects
        });
    };
    
    self.switchViews = function () {
        $('#bookView').toggle('fast');
        $('#otherView').toggle('fast');
    }

    // Fetch the initial data.
    getAllBooks();
    getAuthors();
};


ko.applyBindings(new ViewModel());