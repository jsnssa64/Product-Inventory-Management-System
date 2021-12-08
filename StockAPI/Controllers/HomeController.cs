using Application.Inventory.Queries.Dtos;
using Application.Inventory.WriteModel.Commands;
using AutoMapper;
using CQRSlite.Commands;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICommandSender _commandSender;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ICommandSender commandSender, IQueryProcessor queryProcessor)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _queryProcessor = queryProcessor;
        }

        [HttpPost]
        public async Task<ActionResult> Add(InventoryItemDto item, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateInventoryItemCommand>(item);
            await _commandSender.Send(command, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetInventoryItem(Guid id)
        {

            //await _queryProcessor.Query(new GetInventoryItemDetails(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> ChangeName(Guid id, string name, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RenameInventoryItem(id, name, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Deactivate(Guid id, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new DeactivateInventoryItem(id, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> CheckIn(Guid id)
        {
            ViewData.Model = await _queryProcessor.Query(new GetInventoryItemDetails(id));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CheckIn(Guid id, int number, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new CheckInItemsToInventory(id, number, version), cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Remove(Guid id)
        {
            ViewData.Model = await _queryProcessor.Query(new GetInventoryItemDetails(id));
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Remove(Guid id, int number, int version, CancellationToken cancellationToken)
        {
            await _commandSender.Send(new RemoveItemsFromInventory(id, number, version), cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
