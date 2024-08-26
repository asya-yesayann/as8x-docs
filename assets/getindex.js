function generateIndexList() {
    let content = document.getElementById("index_content");
    content.innerHTML = "";
    var pages = tipuesearch.pages;
    pages.sort((a, b) => {
        if (a.title < b.title)
            return -1;
        if (a.title > b.title)
            return 1;
        return 0;
    });

    for (let page of pages) {
        let loc = page.url;
        let title = page.title ? page.title : page.url;

        let div = document.createElement("div");
        div.setAttribute("data-title", title);
        div.setAttribute("data-tag", page.tags);

        let a = document.createElement("a");
        a.href = loc;
        a.textContent = title;
        div.appendChild(a);

        if (page.pageTitle) {
            let span = document.createElement("span");
            span.innerText = page.pageTitle;
            span.classList.add("index-page-title")
            div.appendChild(span);
        }

        content.appendChild(div);
    }
    let input = document.getElementById("tipue_search_input");
    if (input.value != "") {
        searchText(input);
    }
}

window.addEventListener("load", (ev) => {
    generateIndexList();
    let input = document.getElementById("tipue_search_input");
    input.addEventListener("keyup", (ev) => {
        searchText(input);
    });
    input.addEventListener("change", (ev) => {
        searchText(input);
    });
});

/*
 * Փնտրում է տեքստը api index էջում, և չհամապատասխանող հղուները դարձնում է անտեսանելի։
 *
 * Անտեսանելի է դարձնում նաև այն դեպքերը, երբ տեքտը գտել է տիպի անվան մեջ, այլ ոչ թե հատկության անվան մեջ։
 * Օրինակ՝ input == "Doc", ապա "AsDoc/Caption"-ը կդառնա անտեսանելի։
 */
function searchText(input) {
    let content = document.getElementById("index_content");
    let searchText = input.value.toLowerCase();
    console.log(searchText);
    let anchorArr = content.getElementsByTagName("a");
    for (let anchor of anchorArr) {
        let anchorText = anchor.parentElement.getAttribute("data-title");
        let anchorTextLowered = anchorText.toLowerCase();
        let foundIndex = anchorTextLowered.lastIndexOf(searchText);
        if (foundIndex >= 0) {
            let slashIndex = anchorText.indexOf("/"); //տիպի հատկությունից տարանջատման նիշ
            if (foundIndex > slashIndex) {
                anchor.parentElement.style.display = "";
                if (searchText != "") {
                    let foundIndexEnd = foundIndex + searchText.length;
                    anchor.innerHTML =
                        anchorText.substring(0, foundIndex)
                        + "<mark>" + anchorText.substring(foundIndex, foundIndexEnd) + "</mark>"
                        + anchorText.substring(foundIndexEnd);
                } else {
                    anchor.innerHTML = anchor.parentElement.getAttribute("data-title");
                }
            } else {
                anchor.parentElement.style.display = "none";
            }
        } else {
            anchor.parentElement.style.display = "none";
        }
    }
}
